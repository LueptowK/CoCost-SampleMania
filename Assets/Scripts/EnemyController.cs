using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
Rigidbody rb;
Transform tf;
[SerializeField] protected Transform target;
protected bool isRepaired = false;
protected float maxRepairAmount = 100;
protected float repairAmount;
float repairTime;

// Start is called before the first frame update
protected virtual void Start()
{
    rb = GetComponent<Rigidbody>();
    tf = GetComponent<Transform>();
    repairAmount = maxRepairAmount;

}

// Update is called once per frame
protected virtual void Update()
{

}

public virtual bool Repair(float repairValue)
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