using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : EnemyController
{
    Rigidbody rb;
    Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        repairAmount = maxRepairAmount;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        tf.LookAt(target);

        /*if(isRepaired == true)
        {
            repairTime += Time.deltaTime;
            if(repairTime >= 2.0f)
            {
                transform.LookAt(target);

            }
        }*/
        
    }

}
