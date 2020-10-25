using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;
using UnityEngine.UI;
using SQLite4Unity3d;

public class RegisterPlayer : MonoBehaviour

{
    // public GameObject player_Name;
    public InputField user_name;
    public InputField password;
    
    // Start is called before the first frame update
    void Start()
    {
        
  
    }
     public void CheckUserPassword() {// unity accessable method

        switch (GameModel.CheckPassword(user_name.text, password.text))// comparing the user input against the gameModel method
        {
            case GameModel.PasswdMode.OK:
                Debug.Log("Good Login");
                //GetPlayer();
                // Put name into the text 
                // Gto to the scene or locaiton
                break;
            case GameModel.PasswdMode.NeedName:
                Debug.Log("Need to Register because it is a new name");
                break;
            case GameModel.PasswdMode.NeedPassword:
                Debug.Log("Bad password");
                break;

        }

    }
   public void Register()// Method that is accessable by Unity 
    {
        GameModel.RegisterPlayer(user_name.text, password.text);// Places the user input fields as the parameters for the GameModel RegisterPlayer method

    }
   //void GetPlayer()
   // {
   //     GameModel.currentPlayer = GameModel.ds.getPlayer(user_name.text);
      
   // }

  
}

