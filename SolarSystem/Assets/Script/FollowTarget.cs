using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform currentTarget;
    public float followSpeed = 5f;

    private void LateUpdate()
    {
        // Change the camera position to follow behind and look at the planet
        // with the zoom defined by CameraZoomSettings HandleZoom()
        if (currentTarget != null)
        {
            Vector3 desiredPosition = currentTarget.position;
            desiredPosition.z = GetComponent<CameraZoomSettings>().HandleZoom().z;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.LookAt(currentTarget);
        }
    }

    // Change both the target
    public void SetTarget(Transform newTarget)
    {
        currentTarget = newTarget;
    }
}


