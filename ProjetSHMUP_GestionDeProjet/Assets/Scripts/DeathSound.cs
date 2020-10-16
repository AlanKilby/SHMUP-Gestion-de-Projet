using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    public AudioSource deathSound;

    private void Start()
    {
        deathSound.Play();
    }
}
