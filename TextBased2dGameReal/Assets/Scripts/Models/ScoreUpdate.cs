using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUpdate : MonoBehaviour
{
    public GameObject playerScore;
    public static int Points;

    private void Start()
    {
        playerScore.GetComponent<Text>().text = "Score: " + Points;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        {
            if (collider.CompareTag("Player"))
            {
                Points += 100;// adds 100 value to the points variable
                playerScore.GetComponent<Text>().text = "Score: " + Points;
                Destroy(this.gameObject);// destroys the coin after it has been collected

            }
        }   
    }
}
