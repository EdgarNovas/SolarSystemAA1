using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlanet : MonoBehaviour
{
    public float mass;
    public float initialDistance;
    public float initialVelocity;
 
    public Transform sun;

    float gravityMassConstant = 39.478f;
    Vector3 velocity;
    Vector3 position;
    Vector3 acceleration;
    float timeMotion;
    public float stepTime = 0.001f;
    public float totalTime = 10f;


    private LineRenderer lineRenderer;
    private List<Vector3> trajectoryPoints = new List<Vector3>();
    public Color orbitColor;

    void Start()
    {
        position = new Vector3(initialDistance, 0f, 0f);
        transform.position = position;
        velocity = new Vector3(0f, initialVelocity, 0f);
        timeMotion = 0f;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = orbitColor;
        lineRenderer.endColor = orbitColor;
    }

    void Update()
    {
        if (timeMotion < totalTime)
        {
            acceleration = GravitationalAcceleration();
            (position, velocity, timeMotion) = EulerMethod(position, velocity, acceleration, timeMotion);
            transform.position = position;

            trajectoryPoints.Add(position);
            lineRenderer.positionCount = trajectoryPoints.Count;
            lineRenderer.SetPositions(trajectoryPoints.ToArray());
    }
        else
        {
            return;
        }
    }

    private Vector3 GravitationalAcceleration()
    {
        Vector3 relativePosition = position - sun.position;
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
