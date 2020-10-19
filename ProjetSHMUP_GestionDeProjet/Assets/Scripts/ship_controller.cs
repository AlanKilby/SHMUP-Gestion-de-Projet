using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public MenuPause menuPause;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        rb = GetComponent<Rigidbody2D>();
        ScoreStore.score = 0;
        hp = 5;
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

        if (other.gameObject.CompareTag("EndGame"))
        {
            Time.timeScale = 0f;

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Play Again"))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Level1");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 100, 80, 40), "Quit"))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
    

    public void Death()
    {
        Instantiate(explosion, new Vector3(transform.position.x,transform.position.y), Quaternion.identity);
        menuPause.EnPause2 = true;
        Destroy(gameObject);
        
    }
}


    

