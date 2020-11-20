using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite4Unity3d;
using UnityEngine.UI;

// Is this a factory?

public static class GameModel
    
{
    public static GameObject GamePlayer;
    public static CheckpointController CP;
    public static string PlayingPlayer;// Variable to store the current player nane 
    static String _name;

    public static string Name {
        get
        {
            return _name;
        }
        set {
            _name = value;
        }

    }
    // game model creates public objects of all the tables
    public static Location currentLocale;
    public static Player currentPlayer = null;
    public static Location startLocation;
    public static DataService ds = new DataService("ShadowsOfRonnin.db");

    public static JSONDropService jsDrop = new JSONDropService { Token = "06d8e924-e61e-4b1f-ae2b-8575a0cdf85c" };
    // enum type for value that is one of these.
    // Here enum is being used to determine 
    // Login Reg statuses.
    public enum PasswdMode {
        NeedName,
        NeedPassword,
        OK,
        AllBad
    }

    public static PasswdMode CheckPassword(string pName, string pPassword)
    {
        PasswdMode result = GameModel.PasswdMode.AllBad;

        Player aPlayer = ds.getPlayer(pName);//gets the player name from the database from the player table
        if (aPlayer != null)// if it finds a matching player 
        {
            if (aPlayer.Password == pPassword)// if the player password matches the inputed password
            {
                result = GameModel.PasswdMode.OK;
                GameModel.currentPlayer = aPlayer; // << WATCHOUT THIS IS A SIDE EFFECT
                GameModel.currentLocale = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
                GameModel.PlayingPlayer = pName;
                
            }
            else
            {
                result = GameModel.PasswdMode.NeedPassword;
            }
        }
        else
            result = GameModel.PasswdMode.NeedName;

        return result;
    }

    public static void RegisterPlayer(string pName, string pPassword) // registers the player using the input from the input textboxes
    {
        GameModel.PlayingPlayer = pName;
 
        GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pName, pPassword, GameModel.currentLocale.Id, 100, 200, (float)-3.218, (float)-4.54);
        networkRegister();
    }
  
    public static void networkRegister()
    {
        jsDrop.Create<Person, JsnReceiver>(new Person
        {
            Name = "UUUUUUUUUUU",// give the call an example of the data it needs to store
            Score = 0,
            Password = "***************************"
        }, jsnReceiveCreateDel);
    }

    public static void jsnReceiveCreateDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + "..." + pReceived.Msg);
        jsDrop.Store<Person, JsnReceiver>(new List<Person>
        {
            new Person{Name=GameModel.currentPlayer.Name,Score=0,Password=GameModel.currentPlayer.Password}
        }, jsnReceiverStoreDel);
    }
    public static void jsnReceiverStoreDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + "..." + pReceived.Msg);
    }
    public static void StoreScore(int pScore)
    {
        GameModel.ds.storeHscore(GameModel.ds.getPlayer(GameModel.PlayingPlayer), pScore);

    }

 
    public static void SaveP(float pX, float pY)
    {
         GameModel.ds.storePlayer(GameModel.ds.getPlayer(GameModel.PlayingPlayer), pX, pY);
        
    }

    //public static void  GetCheckpoint()
    //{
    //   GameModel.ds.getAllPlayer();
    //}
   


    public static void SetupGame()
    {
        ds.CreateDB();

    }
    public static void MakeGame()
    {
        // Only make a  game if we dont have locations
        if (!GameModel.ds.haveLocations())
        {

            Location forest, castle;
            currentLocale = GameModel.ds.storeNewLocation("Forest", " Run!! ");// I understand the code

            forest = currentLocale;

            forest.addLocation("North", "Castle", "Crocodiles");

            castle = forest.getLocation("North");
            castle.addLocation("South", forest);
           

            startLocation = currentLocale; // this might be redundant
        }
        else
            currentLocale = GameModel.ds.GetFirstLocation();
       
    }
   

}

