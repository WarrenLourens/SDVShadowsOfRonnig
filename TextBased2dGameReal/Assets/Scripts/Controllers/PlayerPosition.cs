using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerPosition : MonoBehaviour
{
    private CheckpointController cp;

    void Start()
    {
        cp = GameObject.FindGameObjectWithTag("CP").GetComponent<CheckpointController>(); // Gets the reference of the CheckpointColler's object
        transform.position = cp.LastCheckpointPosition;// Sets the position of the GameObject this script is attached too.
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Reloads the Game scene if the spacebar has been pressed.
        {
            SceneManager.LoadScene("Game");
        }
    }
}
