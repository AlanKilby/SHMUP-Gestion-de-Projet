using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Spider_AI : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;
    private float timeHolder;
    private bool isGoingRight = true;

    public AudioSource shoot;

    public GameObject projectile;
    public Transform shotPoint;


    public bool detectPlayer = false;
    public float detectionRadius;

    public float timer = 1.5f;
    public float timerHolder;

    // Start is called before the first frame update
    void Start()
    {
        timeHolder = movementTime;
        timerHolder = timer;
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer = Physics2D.OverlapCircle(gameObject.transform.position, detectionRadius, LayerMask.GetMask("Player"));
        timer -= Time.deltaTime;
        if (isGoingRight && movementTime > 0)
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            movementTime -= Time.deltaTime;


        }
        if (!isGoingRight && movementTime > 0)
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            movementTime -= Time.deltaTime;
        }

        if (movementTime <= 0 && isGoingRight)
        {
            isGoingRight = false;
            movementTime = timeHolder;
            if (detectPlayer && timer <= 0)
            {
                timer = timerHolder;
                Instantiate(projectile, shotPoint.position, transform.rotation);

            }


        }
        if (movementTime <= 0 && !isGoingRight)
        {
            isGoingRight = true;
            movementTime = timeHolder;

            if (detectPlayer && timer <= 0)
            {
                timer = timerHolder;
                Instantiate(projectile, shotPoint.position, transform.rotation);
                
            }
                

        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, detectionRadius);
    }

}

