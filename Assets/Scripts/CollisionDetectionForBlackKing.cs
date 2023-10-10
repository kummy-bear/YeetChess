using UnityEngine;

public class CollisionDetectionForBlackKing : MonoBehaviour
{
    public LayerMask collisionLayer;

    void OnCollisionEnter(Collision collision)
    {
        if ((collisionLayer & 1 << collision.gameObject.layer) != 0)
        {
            Debug.Log("Black king ded");
        }
    }
}