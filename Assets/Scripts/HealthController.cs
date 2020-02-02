using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] protected float currentHealth = 3;
    bool win;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth()
    {
        if (win)
        {
            return;
        }
        if (currentHealth >= 2)
        {
            currentHealth--;
        }
        else
        {
            gameObject.GetComponent<PlayerMover>().Die();
        }
    }

    public void Win()
    {
        win = true;
    }
}
