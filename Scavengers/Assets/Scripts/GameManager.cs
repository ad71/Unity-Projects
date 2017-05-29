using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float turnDelay = 0.1f;
    public static GameManager instance = null;
    public BoardManager boardscript;
    public int playerFoodPoints = 100;
    [HideInInspector] public bool playersTurn = true;

    private int level = 3;
    private List<Enemy> enemies;
    private bool enemiesMoving;


	// Use this for initialization
	void Awake () {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        enemies = new List<Enemy>();
        boardscript = GetComponent<BoardManager>();
        InitGame();
	}

    void InitGame()
    {
        enemies.Clear();
        boardscript.SetupScene(level);
    }
	
    public void GameOver()
    {
        enabled = false;
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0) yield return new WaitForSeconds(turnDelay);

        for(int i = 0; i < enemies.Count; ++i)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].movetime);
        }

        playersTurn = true;
        enemiesMoving = false;
    }
	// Update is called once per frame
	void Update () {
        if (playersTurn || enemiesMoving)
            return;

        StartCoroutine(MoveEnemies());
	}

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }
}
