using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public abstract class PlayerState
{
    private PlayerMover playerMover;
    private Camera cam;
    public bool vulnerable = true;

    public PlayerState(PlayerMover pm)
    {
        playerMover = pm;
        cam = pm.cam;
    }

    public virtual PlayerState FixedUpdate()
    {
        return null;
    }

    public virtual void Update()
    {
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    private void RotateView()
    {

    }

    protected virtual Vector2 GetInput()
    {
        float horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(horizontal, vertical);

        if (input.sqrMagnitude > 1)
        {
            input.Normalize();
        }
        return input;
    }

    protected virtual Collider GetRepairTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(
            playerMover.transform.position + playerMover.transform.forward * 0.5f,
            0.5f,
            LayerMask.GetMask("Enemy"));
        if (colliders.Length > 1)
        {
            //find closest
        }
        else if (colliders.Length == 1)
        {
            return colliders[0];
        }

        return null;
    }
}