﻿using UnityEngine;


public class ControllerManager : MonoBehaviour
{
    public float minJumpTime = 0.5f;
    // Perhaps, respond differently according to game status.
    //~TODO: Consider input response carefully.
    private bool isControllable = true;
    private float horizontalInput;
    private bool isJumpPressed;
    private bool isJumpHolding;
    private bool isSprintHolding;
    private bool isDownHolding;


    private void Update()
    {
        if (isControllable)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            isJumpHolding = Input.GetButton("Jump");
            if (!isJumpPressed)
                isJumpPressed = Input.GetButtonDown("Jump");

            isSprintHolding = Input.GetButton("Sprint");
            isDownHolding = Input.GetButton("Down");
        }
        else
        {
            horizontalInput = 0f;
            isJumpHolding = false;
            isJumpPressed = false;
            isSprintHolding = false;
            isDownHolding = false;
        }
    }

    public void SetControllable(bool isControllable)
    {
        this.isControllable = isControllable;
    }

    public float HorizontalInput()
    {
        //Debug.LogFormat("Input HorizontalMove = {0}", horizontalInput);
        return horizontalInput;
    }

    public bool JumpPressed()
    {
        //Debug.LogFormat("Input JumpPressed = {0}", isJumpPressed);
        return isJumpPressed;
    }

    public void JumpPressedConsumed()
    {
        isJumpPressed = false;
    }

    public bool JumpHolding()
    {
        return isJumpHolding;
    }

    public bool SprintHolding()
    {
        return isSprintHolding;
    }

    public bool DownHolding()
    {
        return isDownHolding;
    }
}
