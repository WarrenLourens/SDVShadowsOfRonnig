using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointController cp;

     void Start()
    {
        cp = GameObject.FindGameObjectWithTag("CP").GetComponent<CheckpointController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))// Checks to see if the gameObject is the has the Player tag attached
        {
            cp.LastCheckpointPosition = transform.position;// Sets the LastCheckpointPosition to the Players current position
            Debug.Log("Checkpoint reached");
        }
    }


}
