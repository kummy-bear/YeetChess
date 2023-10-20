using UnityEngine;

public class CollisionDetectionForWhiteKing : MonoBehaviour
{
    public LayerMask collisionLayer;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throw"))
        {
            Debug.Log("White king ded");
        }
    }
}