using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] enemies;
    List<GameObject> repairedEnemies;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject winImage;
    [SerializeField] GameObject loseImage;
    [SerializeField] GameObject introImage;
    bool gameStarted;
    bool gameEnded;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            EnemyController enemy = enemies[i].GetComponent<EnemyController>();
            enemy.Target = Player.transform;
            enemy.Cam = MainCamera.transform;
            enemy.Manager = this;
        }
        repairedEnemies = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
            SceneManager.LoadScene(0);
        }
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                introImage.SetActive(false);
            }
        }
        if (gameEnded && Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void enemyRepaired(GameObject enemy)
    {
        if (repairedEnemies.Contains(enemy))
        {
            Debug.LogError("Enemy already in 'repairedEnemies'", enemy);
        }
        else
        {
            repairedEnemies.Add(enemy);
            if (repairedEnemies.Count == enemies.Length)
            {
                WinnerWinnerChickenDinnerBitch();
            }
        }
    }

    public void GameOver()
    {
        loseImage.SetActive(true);
        gameEnded = true;
        //Load New Scene
    }

    void WinnerWinnerChickenDinnerBitch()
    {
        Player.GetComponent<PlayerMover>().Win();
        winImage.SetActive(true);
        gameEnded = true;
        //Load Victory Scene
    }
}
