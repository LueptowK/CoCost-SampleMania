﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : EnemyController
{
    // Update is called once per frame
    protected override void Update()
    {
        fireTime -= Time.deltaTime;
        //transform.LookAt(target);
        //Fire();
        if (isRepaired == true)
        {
            repairTime += Time.deltaTime;
            if (repairTime >= 2.0f)
            {
                transform.LookAt(target);
                Fire();
                Debug.Log("Fired!!!");
            }
        }
        
    }

}
