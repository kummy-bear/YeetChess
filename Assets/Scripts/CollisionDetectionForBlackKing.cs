using UnityEngine;

public class CollisionDetectionForBlackKing : MonoBehaviour
{
    public LayerMask collisionLayer;
    [SerializeField] GameObject _wwin;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throw"))
        {
            Debug.Log("Black king ded");
            _wwin.SetActive(true);
        }
    }
}