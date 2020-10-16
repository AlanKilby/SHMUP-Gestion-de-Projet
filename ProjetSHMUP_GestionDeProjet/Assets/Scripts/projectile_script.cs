using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_script : MonoBehaviour
{
    public float speed;
    public bool isPlayer;
    public float destructionTime;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }
    private void Update()
    {
        if(isPlayer)
        transform.Translate(transform.up * speed * Time.deltaTime);

        if(!isPlayer)
            transform.Translate(transform.up * -speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alien") && isPlayer)
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Player") && !isPlayer)
        {
            Destroy(gameObject);
        }
    }

}
