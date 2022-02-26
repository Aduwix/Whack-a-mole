using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private GameController gameController;
    private AudioSource hitSound;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        hitSound = GetComponent<AudioSource>();
        hitSound.volume = 0.2f;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Mole")
        {
            hitSound.Play();
            col.collider.GetComponent<Mole>().Hide();
            gameController.UpdateScore();
        }
    }


    void Update()
    {
        
    }
}
