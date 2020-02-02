using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthController>().currentHealth < 3)
        {
            other.GetComponent<HealthController>().IncreaseHealth();
            Destroy(gameObject);
        }
    }
}
