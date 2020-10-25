using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite4Unity3d;

// Is this a factory?

public static class GameModel
{
    public static CheckpointController CP;
    public static string PlayingPlayer;// Test Variable to store the playing charactr name###################
	static String _name;

	public static string Name{
		get 
		{ 
			return _name;  
		}
		set{
			_name = value; 
		}

	}
    // game model creates public objects of all the tables
    public static Location currentLocale;
    public static Player currentPlayer = null;
    public static Location startLocation;
    public static DataService ds = new DataService("ShadowsOfRonnin.db");
    
    // enum type for value that is one of these.
    // Here enum is being used to determine 
    // Login Reg statuses.
    public  enum PasswdMode{
        NeedName,
        NeedPassword,
        OK,
        AllBad
    }

    public static PasswdMode CheckPassword(string pName, string pPassword)
    {
        PasswdMode result = GameModel.PasswdMode.AllBad;

        Player aPlayer = ds.getPlayer(pName);//gets the player name from the database from the player table
        if( aPlayer != null)// if it finds a matching player 
        {
            if(aPlayer.Password == pPassword)// if the player password matches the inputed password
            {
                result = GameModel.PasswdMode.OK;
                GameModel.currentPlayer = aPlayer; // << WATCHOUT THIS IS A SIDE EFFECT
                GameModel.currentLocale = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
                GameModel.PlayingPlayer = pName;//#############################WORKS
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
        // GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pName, pPassword, GameModel.currentLocale.Id, 100, 200);// justa adding the current location which is the starting location
        //################################################################################################
        GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pName, pPassword, GameModel.currentLocale.Id, 100, 200,(float) -3.218,(float) -4.54);
       //################################################################################################
    }
    public static void SavePlayer(float pX, float pY)//Test to update the current player x,y position########################
    {
       GameModel.currentPlayer = GameModel.ds.CpLocation(pX,pY);// current player is set to null that is why  the database is getting a new entry each time.
    }
    //###############################################TEST 
    public static void UpdateScore(int pScore)
    {
        GameModel.currentPlayer = GameModel.ds.UpdateScore(pScore);
    }
    //###############################################

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

