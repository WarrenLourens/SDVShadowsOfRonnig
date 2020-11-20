using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointController : MonoBehaviour
{
    public GameObject PlayerPlayer;
    private static CheckpointController instance;
    public Vector2 LastCheckpointPosition;
    public GameObject GamePlayer;

    private void Start()
    {
        Player RetrievedPlayer = null;
        GameModel.GamePlayer = GamePlayer;
        RetrievedPlayer = GameModel.ds.getPlayer(GameModel.PlayingPlayer);
        GameModel.GamePlayer.transform.position = new Vector3(RetrievedPlayer.X, RetrievedPlayer.Y, GameModel.GamePlayer.transform.position.z);
    }
    void Awake()
    {
      
        if (instance == null)// Checks to see if the instance object has been created
        {
            GameModel.CP = this;
         


           

            instance = this;// If there is current instance game object then set the current game object 
            DontDestroyOnLoad(instance); // Don't destroy the game object 
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerPlayer.GetComponent<Text>().text = GameModel.PlayingPlayer;
    }
}
