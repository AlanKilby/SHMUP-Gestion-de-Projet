using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detector : MonoBehaviour
{
    public bool attackMode = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attackMode = true;
        }
    }
}
