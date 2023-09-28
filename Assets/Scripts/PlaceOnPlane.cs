using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnOnFirstARPlane : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private ARPlaneManager arPlaneManager;
    private bool hasSpawned = false;

    void Start()
    {
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!hasSpawned)
        {
            foreach (var plane in args.added)
            {
                SpawnPrefabOnPlane(plane);
                break; // Spawn only on the first detected plane
            }
        }
    }

    void SpawnPrefabOnPlane(ARPlane plane)
    {
        // Instantiate the prefab on the detected plane
        Vector3 center = plane.center;
        Quaternion rotation = Quaternion.identity;

        GameObject spawnedPrefab = Instantiate(prefabToSpawn, center, rotation);

        // Set the prefab to be a child of the detected plane
        spawnedPrefab.transform.parent = plane.transform;

        hasSpawned = true;
    }
}
