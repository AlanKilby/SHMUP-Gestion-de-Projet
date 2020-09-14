using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("HIT");
            Destroy(gameObject);    
        }
    }
}
