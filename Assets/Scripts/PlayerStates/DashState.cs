using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.CrossPlatformInput;

public class DashState : PlayerState
{
    PlayerMover playerMover;
    Vector3 move;
    bool jumping;
    bool charging;
    bool grounded;
    bool dashing;
    float dashCost;
    float dashTime;
    Transform cam;
    Vector3 camForward;
    float oldTurnSpeed;
    Vector3 currentDirection;


    public DashState(PlayerMover pm) : base(pm)
    {
        playerMover = pm;
        cam = pm.cam.transform;
        vulnerable = true;
    }

    public override PlayerState FixedUpdate()
    {
        // read inputs
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        dashTime += Time.fixedDeltaTime;

        // calculate move direction to pass to character
        if (cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = v * camForward + h * cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            move = (v * Vector3.forward + h * Vector3.right);
        }

        move = Vector3.Lerp(currentDirection, move, 0.5f);


        // pass all parameters to the character control script
        playerMover.Move(move, false, false);

        if (dashTime >= playerMover.MaxDashTime)
        {
            return new DefaultState(playerMover);
        }

        currentDirection = playerMover.CharacterController.velocity;

        return null;
    }

    public override void LateUpdate()
    {
        currentDirection = playerMover.CharacterController.velocity;
    }

    public override void Enter()
    {
        oldTurnSpeed = playerMover.CharacterController.MovingTurnSpeed;
        //playerMover.CharacterController.MovingTurnSpeed = 360;
        playerMover.CharacterController.SpeedMultiplier = 1.5f;
        currentDirection = playerMover.CharacterController.velocity;
    }

    public override void Exit()
    {
        //playerMover.CharacterController.MovingTurnSpeed = oldTurnSpeed;
        playerMover.CharacterController.SpeedMultiplier = 1;
    }
}