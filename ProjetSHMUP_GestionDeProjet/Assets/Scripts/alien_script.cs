using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_script : MonoBehaviour
{
    public float hp;
    public ParticleSystem explosion;

    private void Start()
    {

    }
    private void Update()
    {
        if(hp <= 0)
        {
            AlienDeath();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("HIT");
            hp--;    
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            AlienDeath();
        }
    }

    

    public void AlienDeath()
    {
        Instantiate(explosion,new Vector3(transform.position.x,transform.position.y),Quaternion.identity);
        ScoreStore.score++;
        Destroy(gameObject);
        
    }
}
