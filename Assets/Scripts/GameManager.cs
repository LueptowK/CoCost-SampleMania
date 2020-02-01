using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] enemies;
    [SerializeField] protected GameObject MainCamera;
    [SerializeField] protected GameObject Player;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().Target = Player.transform;
            enemies[i].GetComponent<EnemyController>().Cam = MainCamera.transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void GameOver()
    {
        gameObject.GetComponent<PlayerMover>().Die();
        //Load New Scene
    }

    void WinnerWinnerChickenDinnerBitch()
    {
        //Load Victory Scene
    }
}
