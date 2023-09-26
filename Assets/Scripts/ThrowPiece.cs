using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class CylinderSpawner : MonoBehaviour
{
    public GameObject cylinderPrefab;
    private ARRaycastManager raycastManager;
    private ARSessionOrigin arSessionOrigin;

    private void Awake()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        arSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                SpawnCylinder();
            }
        }
    }

    private void SpawnCylinder()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        if (hits.Count > 0)
        {
            Pose hitPose = hits[0].pose;
            Vector3 spawnPosition = hitPose.position;

            // Spawn the cylinder
            GameObject cylinder = Instantiate(cylinderPrefab, spawnPosition, Quaternion.identity);
            
            // Calculate the force direction towards the AR camera
            Vector3 cameraPosition = arSessionOrigin.camera.transform.position;
            Vector3 forceDirection = (cameraPosition - spawnPosition).normalized;
            
            // Apply a force to the cylinder
            Rigidbody cylinderRigidbody = cylinder.GetComponent<Rigidbody>();
            cylinderRigidbody.AddForce(forceDirection * 500f); // Adjust force strength as needed
        }
    }
}
