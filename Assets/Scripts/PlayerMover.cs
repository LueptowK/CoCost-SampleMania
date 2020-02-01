using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMover : MonoBehaviour
{
    bool paused;
    public float speed;
    public float stickToGroundForce;
    private CharacterController characterController;
    private CollisionFlags collisionFlags;
    private Camera playerCamera;
    private bool dead;
    private PlayerState currentState;
    [SerializeField] private MouseLook mouseLook;
    public MouseLook MouseLook
    {
        get { return mouseLook; }
    }

    // Use this for initialization
    void Start()
    {
        MouseLook.Init(transform, playerCamera.transform);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            PlayerState newState = currentState.FixedUpdate();
            if (newState != null)
            {
                currentState.Exit();
                newState.Enter();
                currentState = newState;
            }
        }
    }



    void Update()
    {
        if (!dead)
        {
            currentState.Update();
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        //dont move the rigidbody if the character is on top of it
        if (collisionFlags == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(characterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
    }








    public void Move(Vector3 movement)
    {
        collisionFlags = characterController.Move(movement * Time.fixedDeltaTime);
    }

    public void PlayLandSound()
    {

    }

    public RaycastHit GetSurfaceNormal()
    {
        // get a normal for the surface that is being touched to move along it
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, characterController.radius, Vector3.down, out hitInfo,
            characterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        return hitInfo;
    }

    public bool isGrounded()
    {
        return characterController.isGrounded;
    }

    public void Die()
    {
        dead = true;
    }
}
