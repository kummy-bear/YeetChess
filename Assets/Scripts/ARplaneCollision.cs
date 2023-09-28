using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AddColliderToFirstARPlane : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;
    private bool colliderAdded = false;

    void Start()
    {
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!colliderAdded)
        {
            foreach (var plane in args.added)
            {
                AddColliderToARPlane(plane);
                break; // Add a collider to only the first detected plane
            }
        }
    }

    void AddColliderToARPlane(ARPlane plane)
    {
        BoxCollider boxCollider = plane.gameObject.AddComponent<BoxCollider>();
        // Adjust the size and center of the collider as needed
        // For example:
        // boxCollider.size = new Vector3(plane.size.x, 0.01f, plane.size.y);
        // boxCollider.center = new Vector3(0f, 0f, 0f);

        colliderAdded = true;
    }
}
