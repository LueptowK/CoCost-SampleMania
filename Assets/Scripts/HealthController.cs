using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] protected float currentHealth = 3;
    [SerializeField] protected GameObject[] healthImages;
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
            currentHealth = 0;
            gameObject.GetComponent<PlayerMover>().Die();
        }
        DisplayHealth();
    }

    void DisplayHealth()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].SetActive(i < currentHealth);
        }
    }

    public void IncreaseHealth()
    {
        if(currentHealth < 3)
        {
            currentHealth++;
            DisplayHealth();
        }
    }

    public void Win()
    {
        win = true;
    }
}
