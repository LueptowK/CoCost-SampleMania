using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    protected GameManager gameManager;
    public GameManager Manager { set => gameManager = value; }
    protected Rigidbody rb;
    protected Transform tf;
    protected Transform target;
    public Transform Target {set => target = value; }
    protected Transform cam;
    public Transform Cam { set => cam = value; }
    protected bool isRepaired = false;
    public bool Repaired { get => isRepaired; }
    protected float maxRepairAmount = 100;
    protected float repairAmount;
    protected float repairTime;
    protected float startFireTime = 1.5f;
    protected float fireTime;
    [SerializeField] protected float repairDecrementRate;
    [SerializeField] protected float repairTimeBeforeDecrement;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Image repairIndicator;
    protected float repairTimeout;

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
        if (repairTimeout < repairTimeBeforeDecrement)
        {
            repairTimeout += Time.deltaTime;
        }
        if (!isRepaired && repairAmount < maxRepairAmount && repairTimeout >= repairTimeBeforeDecrement)
        {
            
            repairAmount += repairDecrementRate * Time.deltaTime;
            repairIndicator.fillAmount = 1f - repairAmount / maxRepairAmount;
            if (repairAmount > maxRepairAmount)
            {
                repairAmount = maxRepairAmount;
                repairIndicator.fillAmount = 0f;
            }
        }
    }

    public virtual bool Repair(float repairValue)
    {
        repairAmount -= repairValue;
        repairTimeout = 0;
        repairIndicator.fillAmount = 1f - repairAmount / maxRepairAmount;
        if (repairAmount <= 0 && !isRepaired)
        {
            isRepaired = true;
            repairIndicator.color = Color.red;
            gameManager.enemyRepaired(gameObject);
        }
        return isRepaired;
    }

    protected virtual void Fire()
    {
        if (fireTime <= 0){
            fireTime = startFireTime;
            GameObject projectileObject = Instantiate(projectilePrefab, rb.position + new Vector3(0f, 1f, 0f), tf.rotation);
            projectileObject.SetActive(true);
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Target = target;
            projectile.Fire(tf.forward, 10.0f);
        }
    }
}