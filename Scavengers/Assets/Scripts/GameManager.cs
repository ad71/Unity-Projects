using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BoardManager boardscript;
    private int level = 3;


	// Use this for initialization
	void Awake () {
        boardscript = GetComponent<BoardManager>();
        InitGame();
	}

    void InitGame()
    {
        boardscript.SetupScene(level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
