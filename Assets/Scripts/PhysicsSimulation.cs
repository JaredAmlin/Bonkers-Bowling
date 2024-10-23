using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsSimulation : MonoBehaviour
{
    //new simulated scene
    private Scene _simulatedScene;

    //physics scene of simulated scene
    private PhysicsScene _physicsScene;

    //game objects with colliders
    [SerializeField] GameObject[] _simulatedObjects;

    [SerializeField] private GameObject _physicsBall;

    //line renderer and visualization 
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _maxPhysicsIterations = 50;

    //cache variables
    private GameObject _objectToThrow;

    private const string _physicsBallName = "PhysicsBall";
    private const string _physicsSimulationName = "Physics Simulation";
    private const string _simulatedObjectTag = "SimulatedObject";
    private const string _physicsJukeboxName = "PhysicsJukebox";
    private const string _roomCollidersName = "Game Room Colliders";

    #region Initialization
    private void Start()
    {
        NullChecks();

        CreateSimulatedScene();
    }

    private void NullChecks()
    {
        //null check / get line renderer component
        if (_lineRenderer == null & TryGetComponent<LineRenderer>(out LineRenderer renderer))
            _lineRenderer = renderer;

        //disable line renderer
        if (_lineRenderer != null)
            _lineRenderer.enabled = false;

        //check physics ball
        if (_physicsBall == null)
            _physicsBall = Resources.Load<GameObject>(_physicsBallName);

        //check and find simulated objects
        if (_simulatedObjects.Length == 0)
            _simulatedObjects = GameObject.FindGameObjectsWithTag(_simulatedObjectTag);

        //load simulated objects
        if (_simulatedObjects.Length == 0)
        {
            GameObject colliders = Resources.Load<GameObject>(_roomCollidersName);
            GameObject physicsJukebox = Resources.Load<GameObject>(_physicsJukeboxName);

            _simulatedObjects = new GameObject[] { colliders, physicsJukebox };
        }

        //disable the jukebox so it doesn't immediately collide with the game scene jukebox
        foreach (GameObject simulatedObject in _simulatedObjects)
        {
            if (simulatedObject.name == _physicsJukeboxName)
            {
                simulatedObject.gameObject.SetActive(false);
            }
        }
    }

    private void CreateSimulatedScene()
    {
        //create simulated scene
        _simulatedScene = SceneManager.CreateScene(_physicsSimulationName, new CreateSceneParameters(LocalPhysicsMode.Physics3D));

        //get physics scene from simulated scene
        _physicsScene = _simulatedScene.GetPhysicsScene();

        foreach (GameObject obj in _simulatedObjects)
        {
            var simulatedObject = Instantiate(obj, obj.transform.position, obj.transform.rotation);

            if (simulatedObject.GetComponent<MeshRenderer>() != null)
                simulatedObject.GetComponent<MeshRenderer>().enabled = false;

            if (simulatedObject.activeInHierarchy == false)
            {
                simulatedObject.SetActive(true);
            }

            //move objects to simulated scene
            SceneManager.MoveGameObjectToScene(simulatedObject, _simulatedScene);
        }
    }
    #endregion

    public void SimulateTrajectory(Vector3 pos, Vector3 velocity, Vector3 torqueVelocity)
    {
        _objectToThrow = Instantiate(_physicsBall, pos, Quaternion.identity);

        //move simulated object to simulated physics scene
        SceneManager.MoveGameObjectToScene(_objectToThrow, _simulatedScene);

        //apply velocity
        IThrowable throwable = _objectToThrow.GetComponent<IThrowable>();

        if (throwable != null)
            throwable.Throw(velocity, torqueVelocity);

        //line renderer
        _lineRenderer.enabled = true;
        //set the amount of points in the line renderer
        _lineRenderer.positionCount = _maxPhysicsIterations;

        //forloop set position of line renderer based on max physics interactions value
        for (int i = 0; i < _maxPhysicsIterations; i++)
        {
            //simulate the physics scene
            _physicsScene.Simulate(Time.fixedDeltaTime);

            //set position of each point on line rendrer using simulated object position
            _lineRenderer.SetPosition(i, _objectToThrow.transform.position);
        }

        //destroy simulated object
        Destroy(_objectToThrow);
    }

    public void StopLine()
    {
        _lineRenderer.enabled = false;
    }
}
