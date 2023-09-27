using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public GameObject objectToThrow;
    public float throwForce = 10f;
    private Camera arCamera;

    private void Start()
    {
        arCamera = Camera.main; // Get the AR camera
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ThrowObject();
        }
    }

    private void ThrowObject()
    {
        // Create the object clone
        GameObject objClone = Instantiate(objectToThrow, arCamera.transform.position, arCamera.transform.rotation);

        // Get the rigidbody
        Rigidbody rb = objClone.GetComponent<Rigidbody>();

        // Apply force to throw the object forward
        rb.AddForce(arCamera.transform.forward * throwForce, ForceMode.Impulse);
    }
}
