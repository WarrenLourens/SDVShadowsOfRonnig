using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private static CheckpointController instance;
    public Vector2 LastCheckpointPosition;


     void Awake()
    {
        if (instance == null)// Checks to see if the instance object has been created
        {
            instance = this;// If there is current instance game object then set the current game object 
            DontDestroyOnLoad(instance); // Don't destroy the game object 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
