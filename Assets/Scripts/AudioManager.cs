using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Soundtracks")]
    [SerializeField] private AudioClip[] _soundTracks;

    [Header("Record Scratch")]
    [SerializeField] private AudioClip[] _recordScratches;
    private int _randomScratch;
    private int _currentSoundtrack = 0;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _soundTrackSource;
    [SerializeField] private AudioSource _recordScratchFXSource;
    [SerializeField] private AudioSource _strikeSource;
    [SerializeField] private AudioSource _explosionSource;
    [SerializeField] private AudioSource _rackSource;
    [SerializeField] private AudioSource _collectableSource;
    [SerializeField] private AudioSource _applauseSource;
    [SerializeField] private AudioSource _hoverSource;

    [SerializeField] private float _timeToFade = 10f;

    #region Initialization
    // Start is called before the first frame update
    void Start()
    {
        EventSubscriptions();
        Initialization();
    }

    private void EventSubscriptions()
    {
        //free play scene
        BowlingBallFreePlay.onPinsHit += BowlingBallFreePlay_onPinsHit;
        ExplodingBallFreePlay.onExplosion += ExplodingBallFreePlay_onExplosion;
        ExplodingBallFreePlay.onPinsHit += ExplodingBallFreePlay_onPinsHit;
        PinManagerFreePlay.onResetPins += PinManagerFreePlay_onResetPins;
        PinManager.onResetPins += PinManager_onResetPins;

        //game scene
        BowlingBall.onPinsHit += BowlingBall_onPinsHit;
        ExplodingBall.onExplosion += ExplodingBall_onExplosion;
        ExplodingBall.onPinsHit += ExplodingBall_onPinsHit;

        CollectablePin.onCollectablePin += CollectablePin_onCollectablePin;

        GameManager.onDisplayResults += GameManager_onDisplayResults;

        Jukebox.onJukeboxHit += Jukebox_onJukeboxHit;
    }

    private void Initialization()
    {
        if (_soundTracks.Length != 0)
        {
            foreach (AudioClip clip in _soundTracks)
            {
                clip.LoadAudioData();
            }
        }

        if (_soundTrackSource != null)
        {
            _soundTrackSource.clip = _soundTracks[_currentSoundtrack];

            //fade in soundtrack for 10 seconds
            StartCoroutine(FadeInRoutine(_soundTrackSource, _timeToFade));

            _soundTrackSource.Play();
        }
    }
    #endregion

    #region Event Methods
    private void GameManager_onDisplayResults(bool objectivesComplete, bool isGameOver)
    {
        if (objectivesComplete)
        {
            if (_applauseSource != null)
                _applauseSource.Play();
        }
    }

    private void CollectablePin_onCollectablePin()
    {
        if (_collectableSource != null)
            _collectableSource.Play();
    }

    private void PinManager_onResetPins()
    {
        PlayRackSound();
    }

    private void ExplodingBall_onPinsHit()
    {
        PlayStrikeSound();
    }

    private void ExplodingBall_onExplosion()
    {
        PlayExplosionSound();
    }

    private void BowlingBall_onPinsHit()
    {
        PlayStrikeSound();
    }

    private void PinManagerFreePlay_onResetPins()
    {
        PlayRackSound();
    }

    private void ExplodingBallFreePlay_onPinsHit()
    {
        PlayStrikeSound();
    }

    private void ExplodingBallFreePlay_onExplosion()
    {
        PlayExplosionSound();
    }

    private void BowlingBallFreePlay_onPinsHit()
    {
        PlayStrikeSound();
    }

    private void Jukebox_onJukeboxHit()
    {
        PlayRecordScratch();

        //play next soundtrack
        _currentSoundtrack++;

        if (_currentSoundtrack > _soundTracks.Length - 1)
            _currentSoundtrack = 0;

        if (_soundTrackSource != null)
        {
            _soundTrackSource.Stop();

            _soundTrackSource.clip = _soundTracks[_currentSoundtrack];

            _soundTrackSource.Play();
        }
    }
    #endregion

    #region Private Methods
    private void PlayRecordScratch()
    {
        _randomScratch = Random.Range(0, _recordScratches.Length);

        if (_recordScratchFXSource != null)
        {
            _recordScratchFXSource.clip = _recordScratches[_randomScratch];

            _recordScratchFXSource.Play();
        }
    }

    private void PlayStrikeSound()
    {
        if (_strikeSource != null)
            _strikeSource.Play();
    }

    private void PlayExplosionSound()
    {
        if (_explosionSource != null)
            _explosionSource.Play();
    }

    private void PlayRackSound()
    {
        if (_rackSource != null)
            _rackSource.Play();
    }
    #endregion

    private void OnDisable()
    {
        BowlingBallFreePlay.onPinsHit -= BowlingBallFreePlay_onPinsHit;
        ExplodingBallFreePlay.onExplosion -= ExplodingBallFreePlay_onExplosion;
        ExplodingBallFreePlay.onPinsHit -= ExplodingBallFreePlay_onPinsHit;
        PinManagerFreePlay.onResetPins -= PinManagerFreePlay_onResetPins;

        BowlingBall.onPinsHit -= BowlingBall_onPinsHit; 
        ExplodingBall.onExplosion -= ExplodingBall_onExplosion;
        ExplodingBall.onPinsHit -= ExplodingBall_onPinsHit;
        PinManager.onResetPins -= PinManager_onResetPins;

        CollectablePin.onCollectablePin -= CollectablePin_onCollectablePin;
        GameManager.onDisplayResults -= GameManager_onDisplayResults;
        Jukebox.onJukeboxHit -= Jukebox_onJukeboxHit;
    }

    private IEnumerator FadeInRoutine(AudioSource source, float timeToFade)
    {
        float timeElapsed = 0f;

        while (timeElapsed < timeToFade)
        {
            //fade the volume from zero to one over time
            source.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    //mouse hover event
    public void OnHover()
    {
        if (_hoverSource != null)
            _hoverSource.Play();
    }
}
