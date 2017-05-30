﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameovertext;
    private bool gameover;
    private bool restart;
    private int score;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        gameover = false;
        restart = false;
        restartText.text = "";
        gameovertext.text = "";
	}
	
	// Update is called once per frame
	void Update () {
       if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    // We make this function a coroutine so that calling the WaitForSeconds() function doesn't pause the entire game.
    // Somewhat equivalent to a new thread that spawns stuff and waits.
    // IEnumerator is the return type. Idk what it means.
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            hazardCount += 2;
            if(gameover)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
    }
    
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        gameovertext.text = "Game Over!";
        gameover = true;
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }
}