using UnityEngine;
using System.Collections.Generic;

public class PlanetVerlet : MonoBehaviour
{
    [Header("References")]
    public Transform sun;
    public LineRenderer lineRenderer;

    [Header("Planet Data")]
    public float gravitationalConstant = 39.478f;
    public float sunMass = 1.0f;
    public float planetMass = 3e-6f;
    public Vector3 initialVelocity;

    [Header("Simulation")]
    public float timeStep = 0.01f;
    public int maxTrailPoints = 1000; // Prevent unlimited memory usage

    private Vector3 currentPosition;
    private Vector3 previousPosition;
    private List<Vector3> orbitPositions = new List<Vector3>();

    void Start()
    {
        currentPosition = transform.position;
        previousPosition = currentPosition - initialVelocity * timeStep;

        // Optional LineRenderer setup
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.02f;
            lineRenderer.endWidth = 0.02f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.positionCount = 0;
            lineRenderer.useWorldSpace = true;
            lineRenderer.startColor = Color.yellow;
            lineRenderer.endColor = Color.yellow;
        }
    }

    void Update()
    {
        // Compute Gravitational Acceleration only between the Planet and the Sun
        Vector3 acceleration = ComputeGravitationalAcceleration();

        // Verlet Integration Step
        Vector3 newPosition = 2 * currentPosition - previousPosition + acceleration * (timeStep * timeStep);

        // Update positions
        previousPosition = currentPosition;
        currentPosition = newPosition;
        transform.position = currentPosition;

        // Update the orbit trail
        UpdateOrbitTrail();
    }

    Vector3 ComputeGravitationalAcceleration()
    {
        Vector3 directionToSun = sun.position - currentPosition;
        float distance = directionToSun.magnitude;
        return (gravitationalConstant * sunMass / (distance * distance)) * directionToSun.normalized;
    }

    void UpdateOrbitTrail()
    {
        orbitPositions.Add(currentPosition);

        // Limit trail length
        if (orbitPositions.Count > maxTrailPoints)
            orbitPositions.RemoveAt(0);

        lineRenderer.positionCount = orbitPositions.Count;
        lineRenderer.SetPositions(orbitPositions.ToArray());
    }
}

