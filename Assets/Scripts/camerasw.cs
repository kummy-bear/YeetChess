using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public static bool chessing = false;

    private bool isCamera1Active = true;

    void Start()
    {
        // Ensure one camera is enabled, and the other is disabled at the start.
        camera1.enabled = true;
        camera2.enabled = false;
    }

    public void SwitchCameras()
    {
        // Toggle the active state of the cameras.
        isCamera1Active = !isCamera1Active;
        camera1.enabled = isCamera1Active;
        camera2.enabled = !isCamera1Active;
        chessing = !chessing;
    }
}
