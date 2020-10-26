using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class ScoreUpdate : MonoBehaviour
{
    public GameObject CurrentScore;
    public GameObject playerScore;
    public static int Points=0;

    private void Start()
    {
      
        CurrentScore.GetComponent<Text>().text = Points.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        {
            if (collider.CompareTag("Player"))
            {
                Points += 100;// adds 100 value to the points variable
                GameModel.StoreScore(Points);
                CurrentScore.GetComponent<Text>().text = Points.ToString();
               playerScore.GetComponent<Text>().text =GameModel.PlayingPlayer +" : " +Points;// need to get the score from the player table
             
                 Destroy(this.gameObject);// destroys the coin after it has been collected
            }
        }   
    }
}
