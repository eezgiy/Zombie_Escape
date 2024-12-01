using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    private int playerScore;
    private GameObject player;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = 0;
    }

    public void AddScore()
    {
        playerScore++;
    }
    public void PlayerDied() 
    {
        Destroy(player);
    }

    public void EnemyDied(GameObject enemy) 
    {
        Destroy(enemy);
        AddScore();
    }
}
