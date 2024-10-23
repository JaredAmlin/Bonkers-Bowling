using UnityEngine;

public interface IThrowable
{
    //use for applying force and torque to rigidbody
    public void Throw(Vector3 velocity, Vector3 torqueVelocity);
}
