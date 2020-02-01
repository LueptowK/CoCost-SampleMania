using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    protected Rigidbody rb;
    protected Transform tf;
    [SerializeField] protected Transform target;
    [SerializeField] protected Transform cam;
    protected bool isRepaired = false;
    protected float maxRepairAmount = 100;
    protected float repairAmount;
    protected float repairTime;
    protected float startFireTime = 1.5f;
    protected float fireTime;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Image repairIndicator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        fireTime = startFireTime;
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        repairAmount = maxRepairAmount;
        repairIndicator.fillAmount = 0f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        repairIndicator.transform.LookAt(cam);
    }

    public virtual bool Repair(float repairValue)
    {
        repairAmount -= repairValue;
        repairIndicator.fillAmount = 1f - repairAmount / maxRepairAmount;
        if (repairAmount <= 0)
        {
            isRepaired = true;
            repairIndicator.fillAmount = 0f;
        }
        return isRepaired;
    }

    protected virtual void Fire()
    {
        Vector3 lookDirection = new Vector3(1, 0, 0);
        if (fireTime <= 0){
            fireTime = startFireTime;
            GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector3.up * 0.5f, Quaternion.identity);

            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Fire(lookDirection, 300.0f);
            Debug.Log("Fired:)");
        }
    }
}