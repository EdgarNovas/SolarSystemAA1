using UnityEngine;

public class CameraZoomSettings : MonoBehaviour
{
    public float zoomSpeed = 200f;

    // To limit how far or close you can get
    public float minZoomDistance = 10f;     
    public float maxZoomDistance = 500f;    
    public Transform target;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
            cam = Camera.main;

        if (target == null)
            target = GameObject.Find("Sun").transform; 
    }

    void Update()
    {
        transform.position = HandleZoom();
    }

    public Vector3 HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 direction = transform.position;
        float newDistance = 1;

        if (Mathf.Abs(scroll) != 0.0f)
        {
            direction = (transform.position - target.position).normalized;
            float distance = Vector3.Distance(transform.position, target.position);

            // Compute the intended new distance
            newDistance = distance - scroll * zoomSpeed;
            newDistance = Mathf.Clamp(newDistance, minZoomDistance, maxZoomDistance);
        }

        // Compute the camera's new position based on the new distance
        return target.position + direction * newDistance;
    }
}
