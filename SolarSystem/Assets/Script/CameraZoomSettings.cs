using UnityEngine;

public class CameraZoomSettings : MonoBehaviour
{
    public float zoomSpeed = 50f;           // Tweak this based on your scale
    public float minZoomDistance = 10f;     // How close you can get
    public float maxZoomDistance = 500f;    // How far you can zoom out
    public Transform target;                // The "Sun" or System Center

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
            cam = Camera.main;

        if (target == null)
            target = GameObject.Find("Sun").transform; // Auto-assign Sun if not set
    }

    void Update()
    {
        HandleZoom();
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 direction = (transform.position - target.position).normalized;
            float distance = Vector3.Distance(transform.position, target.position);

            // Compute the intended new distance
            float newDistance = distance - scroll * zoomSpeed;
            newDistance = Mathf.Clamp(newDistance, minZoomDistance, maxZoomDistance);

            // Update the camera's position based on the new distance
            transform.position = target.position + direction * newDistance;
        }
    }
}
