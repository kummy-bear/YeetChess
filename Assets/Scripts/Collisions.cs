using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // This method is called when a collision occurs.
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the objects you're interested in.
        if (collision.gameObject.CompareTag("YourTargetTag"))
        {
            // Handle the collision here.
            Debug.Log("Collision detected with: " + collision.gameObject.name);
            // You can add more logic here, like destroying the thrown object or applying forces.
        }
    }
}
