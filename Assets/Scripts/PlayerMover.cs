using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerMover : MonoBehaviour
{
    bool paused;
    [SerializeField] private float speed;
    [SerializeField] float repairRate;
    public float RepairRate { get => repairRate; }
    [SerializeField] float dashSpeedMultiplier;
    public float DashSpeedMultiplier { get => dashSpeedMultiplier; }
    [SerializeField] float maxDashTime;
    public float MaxDashTime { get => maxDashTime; }
    [SerializeField] private ThirdPersonCharacter characterController;
    public ThirdPersonCharacter CharacterController { get => characterController; }
    private CollisionFlags collisionFlags;
    private bool dead;
    private PlayerState currentState;
    [SerializeField] public Camera cam;

    // Use this for initialization
    void Start()
    {
        currentState = new DefaultState(this);
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

    private void LateUpdate()
    {
        if (!dead)
        {
            currentState.LateUpdate();
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








    public void Move(Vector3 movement, bool crouch, bool jump)
    {
        characterController.Move(movement * speed, crouch, jump);
    }

    public void PlayLandSound()
    {

    }

    //public RaycastHit GetSurfaceNormal()
    //{
    //    // get a normal for the surface that is being touched to move along it
    //    RaycastHit hitInfo;
    //    Physics.SphereCast(transform.position, characterController.radius, Vector3.down, out hitInfo,
    //        characterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
    //    return hitInfo;
    //}

    //public bool isGrounded()
    //{
    //    return characterController.isGrounded;
    //}

    public void Die()
    {
        dead = true;
        cam.gameObject.GetComponent<GameManager>().GameOver();
    }

    public void Win()
    {
        GetComponent<HealthController>().Win();
    }
}
