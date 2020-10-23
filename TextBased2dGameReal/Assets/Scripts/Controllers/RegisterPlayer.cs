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
     public void CheckUserPassword() {

        switch (GameModel.CheckPassword(user_name.text, password.text))
        {
            case GameModel.PasswdMode.OK:
                Debug.Log("Good Login");
              //  GetPlayer();
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
   public void Register()
    {
        GameModel.RegisterPlayer(user_name.text, password.text);

    }
   void GetPlayer()
    {
        GameModel.currentPlayer = GameModel.ds.getPlayer(user_name.text);
      
    }

  
}

