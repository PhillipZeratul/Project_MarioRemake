﻿using UnityEngine;
using Zenject;


public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float jumpSpeed = 20f;

    private PhysicsObject physicsObject;
    private ControllerManager controllerManager;

    [Inject]
    private void Init(ControllerManager _controllerManager)
    {
        controllerManager = _controllerManager;
    }

    private void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();
    }

    private void FixedUpdate()
    {
        float velocityX = controllerManager.HorizontalMove() * horizontalSpeed;

        if (physicsObject.IsGrounded() && controllerManager.JumpPressed())
        {
            physicsObject.Move(velocityX, jumpSpeed);
        }
        else if (physicsObject.GetVelocityY() > 0f && !controllerManager.JumpHolding())
        {
            physicsObject.Move(velocityX, physicsObject.GetVelocityY() / 2);
        }
        else
            physicsObject.Move(velocityX);

        controllerManager.JumpPressedConsumed();
    }
}
