using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Mole : MonoBehaviour
{
    private GameController gameController;

    private float hiddenHeight = -1f;
    private float visibleHeight = 0.3f;
    private float speed = 8f;
    private Vector3 newPosition;
    private float changeStateTimer = 1f;


    private float showMoleTimerLowerBound = 1.2f; //Mole needs to be visible for at least this much time
    private float showMoleTimerUpperBound = 2.5f; //Mole will not be visible for more than this duration

    private float hideMoleTimerLowerBound = 1f; //Mole needs to be hidden for at least this much time
    private float hideMoleTimerUpperBound = 5f; //Mole will not be hidden for more than this duration

    private bool isGameRunning = false;

    static private Random random = new System.Random();

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        Hide();
        transform.position = newPosition;
    }

    void Show()
    {
        showMoleTimerLowerBound -= 0.05f;
        showMoleTimerUpperBound -= 0.075f;

        changeStateTimer = (float)random.NextDouble() * (showMoleTimerUpperBound - showMoleTimerLowerBound) + showMoleTimerLowerBound;

        newPosition = new Vector3(
            transform.position.x,
            visibleHeight,
            transform.position.z
        );
    }

    public void Hide()
    {
        hideMoleTimerLowerBound -= 0.05f;
        hideMoleTimerUpperBound -= 0.1f;

        changeStateTimer = (float)random.NextDouble() * (hideMoleTimerUpperBound - hideMoleTimerLowerBound) + hideMoleTimerLowerBound;

        newPosition = new Vector3(
            transform.position.x,
            hiddenHeight,
            transform.position.z
        );
    }

    void ChangeState()
    {
        if (transform.position.y == hiddenHeight)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void init()
    {
        changeStateTimer = (float)random.NextDouble() * hideMoleTimerUpperBound;
    }

    public void Update()
    {
        if (gameController._startGame)
        {
            if (!isGameRunning)
            {
                isGameRunning = true;
                init();
            }
            
            changeStateTimer -= Time.deltaTime;

            if (changeStateTimer < 0f)
            {
                ChangeState();
            }
        }
        else
        {
            if (isGameRunning) Hide();
            isGameRunning = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
}
