using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.CrossPlatformInput;

public class DefaultState : PlayerState
{
    PlayerMover playerMover;
    Vector3 move;
    bool jumping;
    bool charging;
    bool grounded;
    bool dashing;
    float dashCost;
    Transform cam;
    Vector3 camForward;


    public DefaultState(PlayerMover pm) : base(pm)
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
        bool crouch = Input.GetKey(KeyCode.C);

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

        // pass all parameters to the character control script
        playerMover.Move(move, crouch, false);

        if (Input.GetButtonDown("Fire1"))
        {
            return new RepairingState(playerMover);
        }

        return null;
    }

    public override void Update()
    {
        move.y = 0f;

        //grounded = playerMover.isGrounded();

    }

    public override void Enter()
    {
        move.y = 0f;
    }


}
