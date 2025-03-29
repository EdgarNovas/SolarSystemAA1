using UnityEngine;

public class PlanetFocusToggle : MonoBehaviour
{
    public FollowTarget followTarget;
    public Transform sun, mercury, venus, earth, mars, jupiter, saturn, uranus, neptune;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            followTarget.SetTarget(sun);      

        if (Input.GetKeyDown(KeyCode.Alpha2))
            followTarget.SetTarget(mercury);   

        if (Input.GetKeyDown(KeyCode.Alpha3))
            followTarget.SetTarget(venus);     

        if (Input.GetKeyDown(KeyCode.Alpha4))
            followTarget.SetTarget(earth);     

        if (Input.GetKeyDown(KeyCode.Alpha5))
            followTarget.SetTarget(mars);      

        if (Input.GetKeyDown(KeyCode.Alpha6))
            followTarget.SetTarget(jupiter);  

        if (Input.GetKeyDown(KeyCode.Alpha7))
            followTarget.SetTarget(saturn);   

        if (Input.GetKeyDown(KeyCode.Alpha8))
            followTarget.SetTarget(uranus);   

        if (Input.GetKeyDown(KeyCode.Alpha9))
            followTarget.SetTarget(neptune);  
    }
}

