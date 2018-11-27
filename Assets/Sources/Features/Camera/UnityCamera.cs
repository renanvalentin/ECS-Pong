using UnityEngine;

public class UnityCamera : ICamera
{
    public Vector3 ScreenToWorldPoint(Vector3 screen)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public Vector3 Position
    {
        get { return Camera.main.transform.position; }
    }
}