using UnityEngine;

public class PlanetFocusToggle : MonoBehaviour
{
    public FollowTarget followTarget;
    public Transform sun, mercury, venus, earth, mars, jupiter, saturn, uranus, neptune;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            followTarget.SetTarget(sun, new Vector3(0, 0, 10));      

        if (Input.GetKeyDown(KeyCode.Alpha2))
            followTarget.SetTarget(mercury, new Vector3(0, 0, 10));   

        if (Input.GetKeyDown(KeyCode.Alpha3))
            followTarget.SetTarget(venus, new Vector3(0, 0, 10));     

        if (Input.GetKeyDown(KeyCode.Alpha4))
            followTarget.SetTarget(earth, new Vector3(0, 0, 10));     

        if (Input.GetKeyDown(KeyCode.Alpha5))
            followTarget.SetTarget(mars, new Vector3(0, 0, 10));      

        if (Input.GetKeyDown(KeyCode.Alpha6))
            followTarget.SetTarget(jupiter, new Vector3(0, 0, 10));  

        if (Input.GetKeyDown(KeyCode.Alpha7))
            followTarget.SetTarget(saturn, new Vector3(0, 0, 10));   

        if (Input.GetKeyDown(KeyCode.Alpha8))
            followTarget.SetTarget(uranus, new Vector3(0, 0, 10));   

        if (Input.GetKeyDown(KeyCode.Alpha9))
            followTarget.SetTarget(neptune, new Vector3(0, 0, 10));  
    }
}

