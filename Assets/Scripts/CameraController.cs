using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform cam;
    [SerializeField] private float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam.LookAt(player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Mouse X") * cam.right * horizontalSpeed * Time.deltaTime);
    }
}
