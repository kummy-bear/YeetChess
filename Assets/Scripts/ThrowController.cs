using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public GameObject throwObject;

    private bool canThrow = true; // You can control whether the cube can be thrown

    private void Update()
    {
        // Handle the touch input for world space (non-UI) taps
        if (canThrow && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Raycast from the AR camera to determine if the cube is tapped
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

        }
    }
}