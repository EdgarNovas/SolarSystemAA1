using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform currentTarget;
    public Vector3 offset = new Vector3(0, 0, -50);
    public float followSpeed = 5f;

    private void LateUpdate()
    {
        if (currentTarget != null)
        {
            Vector3 desiredPosition = currentTarget.position + offset;
            desiredPosition.z = GetComponent<CameraZoomSettings>().HandleZoom().z;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.LookAt(currentTarget);
        }
    }

    // Change both the target and the offset dynamically
    public void SetTarget(Transform newTarget, Vector3 newOffset)
    {
        currentTarget = newTarget;
        offset = newOffset;
    }
}


