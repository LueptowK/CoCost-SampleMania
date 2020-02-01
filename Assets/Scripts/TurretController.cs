using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    public Transform target;
    public bool isRepaired = false;
    public float maxRepairAmount = 100;
    public float repairAmount;
    float repairTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        repairAmount = maxRepairAmount;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRepaired == true)
        {
            repairTime += Time.deltaTime;
            if(repairTime >= 2.0f)
            {
                transform.LookAt(target);

            }
        }
        
    }

    public bool Repair(float repairValue)
    {
        repairAmount = repairAmount - repairValue;

        if (repairAmount <= 0)
        {
            isRepaired = true;
            return isRepaired;
        }
        else
        {
            return isRepaired;
        }
    }
}
