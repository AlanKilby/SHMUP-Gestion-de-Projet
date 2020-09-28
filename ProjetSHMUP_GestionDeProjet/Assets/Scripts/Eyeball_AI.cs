using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball_AI : MonoBehaviour
{
    //public GameObject playerDetector;

    public float movementSpeed;
    public Transform playerPos;

    public bool detectPlayer = false;

    public float detectionRadius;

    private void Update()
    {
        detectPlayer = Physics2D.OverlapCircle(gameObject.transform.position, detectionRadius,LayerMask.GetMask("Player"));


        if (detectPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.transform.position, movementSpeed * Time.deltaTime);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position,detectionRadius);
    }
}
