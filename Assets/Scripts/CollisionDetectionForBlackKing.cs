using UnityEngine;

public class CollisionDetectionForBlackKing : MonoBehaviour
{
    public LayerMask collisionLayer;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throw"))
        {
            Debug.Log("Black king ded");
        }
    }
}