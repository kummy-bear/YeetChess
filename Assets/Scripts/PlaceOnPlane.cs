using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPrefabPlacement : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private ARRaycastManager raycastManager;
    private bool hasSpawned = false;

    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (!hasSpawned && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Create a ray from the screen point
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                // Perform the raycast
                if (raycastManager.Raycast(ray, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;
                    Instantiate(prefabToSpawn, hitPose.position, hitPose.rotation);
                    hasSpawned = true;
                }
            }
        }
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
}
