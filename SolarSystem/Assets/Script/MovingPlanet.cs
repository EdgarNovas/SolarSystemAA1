using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlanet : MonoBehaviour
{
    float mass = 1000;
    Vector3 velocity = new Vector3(10f, 10f);
    Vector3 position = new Vector3(0f, 0f);
    Vector3 acceleration = new Vector3(0f, 0f);
    public Transform sun;
    Vector3 initialPosition = new Vector3(1f, 0f);
    Vector3 initialVelocity = new Vector3(0f, 2 * Mathf.PI);
    float gravityMassConstant = 4 * Mathf.PI * Mathf.PI;
    public float totalTime = 10f;
    float timeMotion;
    public float stepTime = 0.001f;

    float drag = .2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;
        velocity = initialVelocity;
        position = initialPosition;
        timeMotion = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeMotion < totalTime)
        {
            acceleration = GravitationalAcceleration();
            (position, velocity, timeMotion) = EulerMethod(position, velocity, acceleration, timeMotion);
            transform.position = position;
        }
        else
        {
            return;
        }
    }

    private Vector3 GravitationalAcceleration()
    {
        //float distanceSquared = position.magnitude * position.magnitude;
        //Vector3 unityVector = -position.normalized;

        Vector3 relativePosition = transform.position - sun.position;
        float distanceSquared = relativePosition.sqrMagnitude;
        Vector3 unityVector = -relativePosition.normalized;

        Vector3 newAcceleration = (gravityMassConstant / distanceSquared) * unityVector;
        return newAcceleration;
    }

    private (Vector3 position, Vector3 velocity, float timeMotion) EulerMethod(Vector3 position, Vector3 velocity, Vector3 acceleration, float timeMotion)
    {
        Vector3 newPosition = position + velocity * stepTime;
        Vector3 newVelocity = velocity + acceleration * stepTime;

        timeMotion = timeMotion + stepTime;
        return (newPosition, newVelocity, timeMotion);
    }
}
