using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalComponent : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            Debug.Log("GAME WON! :D");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
