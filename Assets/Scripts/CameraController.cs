using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform cam;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float distance;
    [SerializeField] private float height;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        cam.LookAt(player);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        offset = new Vector3(player.position.x, player.position.y + height, player.position.z + distance);
    }
    
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * horizontalSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}
