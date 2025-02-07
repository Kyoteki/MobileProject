using System;
using UnityEngine;

public class OneWayObstacle : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _colliderOnWay;

    private void Update()
    {
        Vector3 playerToOnWay = GameManager.Instance.PlayerPosition - transform.position;
        
        float dotProduct = Vector3.Dot(transform.right, playerToOnWay);

        if (dotProduct < -0.1f)
        {
            _colliderOnWay.gameObject.SetActive(false);
        }
        else
        {
            _colliderOnWay.gameObject.SetActive(true);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.right);
    }
}
