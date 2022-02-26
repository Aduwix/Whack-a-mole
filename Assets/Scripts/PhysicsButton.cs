using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = .025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1) Pressed();

        if (isPressed && GetValue() - threshold <= 0) Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition / joint.linearLimit.limit);

        if (Math.Abs(value) < deadZone) value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        if (!gameController._startGame) gameController.startGame();
    }

    private void Released()
    {
        isPressed = false;
    }
}
