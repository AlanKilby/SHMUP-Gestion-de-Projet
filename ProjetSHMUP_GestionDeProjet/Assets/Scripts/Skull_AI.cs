using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull_AI : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;
    private float timeHolder;
    private bool isGoingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        timeHolder = movementTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoingRight && movementTime > 0)
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            movementTime -= Time.deltaTime;


        }
        if (!isGoingRight && movementTime > 0)
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            movementTime -= Time.deltaTime;
        }

        if(movementTime <= 0 && isGoingRight)
        {
            isGoingRight = false;
            movementTime = timeHolder;
        }
        if (movementTime <= 0 && !isGoingRight)
        {
            isGoingRight = true;
            movementTime = timeHolder;
        }


    }
}
