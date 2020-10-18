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

        Player aPlayer = ds.getPlayer(pName);
        if( aPlayer != null)
        {
            if(aPlayer.Password == pPassword)
            {
                result = GameModel.PasswdMode.OK;
                GameModel.currentPlayer = aPlayer; // << WATCHOUT THIS IS A SIDE EFFECT
                GameModel.currentLocale = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
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
       
        GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pName, pPassword, GameModel.currentLocale.Id, 100, 200);
    }


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
            currentLocale = GameModel.ds.storeNewLocation("Forest", " Run!! ");

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

