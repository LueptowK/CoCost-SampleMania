using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Transform tf;
    Rigidbody rb;
    Transform target;
    public Transform Target { set => target = value; }
    float collisionNumber;


    // Start is called before the first frame update
    void Awake()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        collisionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 3000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Vector3 direction, float speed)
    {
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Transform e = other.GetComponent<Transform>();
        if (e == target)
        {
            other.gameObject.GetComponent<HealthController>().ReduceHealth();
            Destroy(gameObject);

        }
        if(collisionNumber >= 1)
        {
            Destroy(gameObject);
        }
        collisionNumber++;
    }
}
