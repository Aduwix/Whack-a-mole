using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Mole")
        {
            col.collider.GetComponent<Mole>().Hide();
            gameController.UpdateScore();
        }
    }


    void Update()
    {
        
    }
}
