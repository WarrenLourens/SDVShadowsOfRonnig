using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{

    private CheckpointController cp;
    public GameObject DisplayCheckpoint;

     void Start()
    {
        cp = GameObject.FindGameObjectWithTag("CP").GetComponent<CheckpointController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))// Checks to see if the gameObject is the has the Player tag attached
        {
            cp.LastCheckpointPosition = transform.position;// Sets the LastCheckpointPosition to the Players current position
            DisplayCheckpoint.SetActive(true);

                GameModel.currentPlayer = GameModel.ds.CpLocation(transform.position.x, transform.position.y);
            GameModel.SaveP(transform.position.x,transform.position.y);// Test to update current player
            
            DisplayCheckpoint.GetComponent<Text>().text = "You have reached a checkpoint";
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DisplayCheckpoint.SetActive(false);
        }
    }


}
