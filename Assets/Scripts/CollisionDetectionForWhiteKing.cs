using UnityEngine;

public class CollisionDetectionForWhiteKing : MonoBehaviour
{
    public LayerMask collisionLayer;
    [SerializeField] GameObject _bwin;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throw"))
        {
            Debug.Log("White king ded");
            _bwin.SetActive(true);
        }
    }
}