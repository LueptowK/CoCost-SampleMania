using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.CrossPlatformInput;

public class RepairingState : PlayerState
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
    EnemyController repairTarget;
    Quaternion rotation;


    public RepairingState(PlayerMover pm) : base(pm)
    {
        playerMover = pm;
        cam = pm.cam.transform;
        vulnerable = true;
    }

    public override PlayerState FixedUpdate()
    {
        if (playerMover.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            playerMover.Anim.Play("Repair", -1, 0f);
        }
        playerMover.transform.rotation = rotation;

        if (Input.GetButton("Fire1"))
        {
            playerMover.Move(Vector3.zero, true, false);
            if (repairTarget != null)
            {
                repairTarget.Repair(playerMover.RepairRate);
            }
            return null;
        }
        else
        {
            playerMover.Move(Vector3.zero, false, false);
            return new DefaultState(playerMover);
        }

    }

    public override void Enter()
    {
        Collider target = GetRepairTarget();
        if (target != null)
        {
            repairTarget = target.gameObject.GetComponent<EnemyController>();
            repairTarget.Repair(playerMover.RepairRate);
        }
        playerMover.Anim.Play("Repair", -1, 0f);
        rotation = playerMover.transform.rotation;
    }

    public override void Exit()
    {

    }
}