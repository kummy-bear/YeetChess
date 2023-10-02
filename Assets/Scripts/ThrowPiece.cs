using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
            if (!IsPointerOverUIObject())
            {
                ThrowObject();
            }
        }
    }

    private void ThrowObject()
    {
        if (!CameraSwitcher.chessing)
        {
            // Create the object clone
            GameObject objClone = Instantiate(objectToThrow, arCamera.transform.position, arCamera.transform.rotation);

            // Get the rigidbody
            Rigidbody rb = objClone.GetComponent<Rigidbody>();

            // Apply force to throw the object forward
            rb.AddForce(arCamera.transform.forward * throwForce, ForceMode.Impulse);
        }
        
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // Raycast to check if the pointer (touch) is over a UI element
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
