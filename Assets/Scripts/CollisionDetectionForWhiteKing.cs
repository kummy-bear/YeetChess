using UnityEngine;

public class CollisionDetectionForWhiteKing : MonoBehaviour
{
    public LayerMask collisionLayer;

    void OnCollisionEnter(Collision collision)
    {
        if ((collisionLayer & 1 << collision.gameObject.layer) != 0)
        {
            Debug.Log("Collision detected with an object in the collision layer.");
        }
    }
}