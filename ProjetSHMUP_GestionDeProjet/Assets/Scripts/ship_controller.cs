using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_controller : MonoBehaviour
{

    public float shipSpeed;
    private Rigidbody2D rb;

    public GameObject projectile;
    public Transform shotPoint;

    public float horizontalMove;

    public float hp;

    public ParticleSystem explosion;

    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScoreStore.score = 0;
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        rb.gravityScale = 0;

        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove == 1)
        {
            rb.velocity = Vector2.right * shipSpeed;
        }
        else if (horizontalMove == -1)
        {
            rb.velocity = Vector2.left * shipSpeed;

        }
        else if (horizontalMove == 0)
        {
            rb.velocity = Vector2.zero;
        }


        if (Input.GetButtonDown("shoot"))
        {
            playerAudio.Play();

            Instantiate(projectile, shotPoint.position, transform.rotation);
        }


        if(hp <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Alien"))
        {
            hp--;
        }

        if (other.gameObject.CompareTag("enemy_bullet"))
        {
            hp--;
        }
    }
    

    public void Death()
    {
        Instantiate(explosion, new Vector3(transform.position.x,transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }
}


    

