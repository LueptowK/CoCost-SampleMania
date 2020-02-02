using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<HealthController>().IncreaseHealth();
        Destroy(gameObject);
    }
}
