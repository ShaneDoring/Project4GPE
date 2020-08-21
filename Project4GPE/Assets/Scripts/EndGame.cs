using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherObject)
    {

        if (otherObject.gameObject.CompareTag("Player"))
        {
            GameManager.instance.gameState = "Victory Screen";
            GameManager.instance.LoadNextScene();

        }
    }
}
