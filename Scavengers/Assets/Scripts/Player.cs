using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {

    public int wallDamage = 1;
    public int pointsPerfood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDelay = 1f;

    private Animator animator;
    private int food;

	// Use this for initialization
	protected override void Start () {
        animator = GetComponent<Animator>();
        food = GameManager.instance.playerFoodPoints;
        base.Start();
	}

    private void OnDisable()
    {
        GameManager.instance.playerFoodPoints = food;
    }

    // Update is called once per frame
    void Update () {
        if (!GameManager.instance.playersTurn) return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0)
            AttemptMove<Wall>(horizontal, vertical);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
        else if(collision.tag == "Food")
        {
            food += pointsPerfood;
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Soda")
        {
            food += pointsPerSoda;
            collision.gameObject.SetActive(false);
        }
    }

    protected override void OnCantMove<T>(T component)
    {
        //throw new NotImplementedException();
        Wall hitwall = component as Wall;
        hitwall.DamageWall(wallDamage);
        animator.SetTrigger("playerChop");
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseFood(int loss)
    {
        animator.SetTrigger("playeHit");
        food -= loss;
        CheckIfGameOver();
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        food--;
        base.AttemptMove<T>(xDir, yDir);
        RaycastHit2D hit;
        CheckIfGameOver();
        GameManager.instance.playersTurn = false;
    }

    private void CheckIfGameOver()
    {
        if(food <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
