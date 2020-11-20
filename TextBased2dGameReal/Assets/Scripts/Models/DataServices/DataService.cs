using SQLite4Unity3d;
using UnityEngine;
using System.Linq;
// DataService is a bridge to SQlite 
// =================================
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  { 

	private SQLiteConnection _connection; // open a connection to  to the sqlite database

    public SQLiteConnection Connection { get { return _connection; } }
	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);// This the creating a path for the database to get placed when it is created  alone with the database paramenter created
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create); // this creates the actual database
        Debug.Log("Final PATH: " + dbPath);     

	}


    public void SaveLocations(List<Location> Locations)
    {
        _connection.DropTable<Location>();
        _connection.CreateTable<Location>();
        _connection.InsertAll(Locations);
    }

    public List<Location> LoadLocations()
    {
        return _connection.Table<Location>().ToList<Location>();
    }

    public bool HaveLocations()
    {
        try {
            return LoadLocations().Count > 0;
        }
        catch
        {
            return false;
        }

    }


    /* ====== */
	public void CreateDB(){
        // remove these once testing is sorted
       // _connection.DropTable<Location>(); 
       // _connection.DropTable<ToFrom>();
       // _connection.DropTable<Player>();

        // creating the schema
        _connection.CreateTable<Location>(); // each of these are the are the names of the tables needing to be created when the CreateDB method is called 
        _connection.CreateTable<ToFrom>();
        _connection.CreateTable<Player>();

    }

    // Locations and their relationships 
    public IEnumerable<Location> GetLocations()
    {
        return _connection.Table<Location>();
    }

    public Location GetFirstLocation()
    {
        Location aLocation = _connection.Table<Location>().FirstOrDefault<Location>();
        return aLocation;
    }
    public bool haveLocations()
    {
        return _connection.Table<Location>().Count() > 0;
    }

    public ToFrom GetToFrom(int pFromID, string pDirection)
    {
        return _connection.Table<ToFrom>().Where(tf => tf.FromID == pFromID
                                                      && tf.Direction == pDirection).FirstOrDefault();      
    }

    public Location GetLocation(int pLocationID)// This method is called in the getPlayerLocation method below
    {
        return _connection.Table<Location>().Where(l => l.Id == pLocationID).FirstOrDefault();
    }

    public Location GetPlayerLocation (Player aPlayer)
    {
        return GetLocation(aPlayer.LocationId);

    }

    //##################################################################################################
    // Added method of updateing the private X,Y proprties in the player 
    //public Player CpLocation(float pX, float pY)
    //{

    //    Player newLocation = GameModel.currentPlayer; // CREATES A NEW ENTRY EACH TIME @ ISSUE@
    //    {
    //        newLocation.X = pX;
    //        newLocation.Y = pY;
    //    }
    //    _connection.Insert(newLocation);

    //    return (newLocation);

    //}
    public void storeHscore(Player pPlayer, int pScore) //Works 8)
    {
        pPlayer.HiScore = pScore;

        _connection.InsertOrReplace(pPlayer);
    }
   
    public Location storeNewLocation(string pName, string pStory)
    {
        Location newLocation = new Location// creating a new object of type location
        {
            Name = pName,// setting the parameter value against the property of the class Location
            Story = pStory
        };
        _connection.Insert(newLocation); // Store the location 
        return newLocation;  // return the location
    }
 

    public void storeFromTo(int pFromID, int pToID, string pDirection)
    {
        ToFrom f = new ToFrom
        {
            ToID = pToID,
            FromID = pFromID,
            Direction = pDirection
        };
        _connection.Insert(f);

    }
    
    public Player storeNewPlayer(string pName, string pPassword,
                            int pLocationId, int pHealth,
                            int pWealth, float pX, float pY)
    {
        Player player = new Player // creating a object of the player class
        {
            Name = pName,  // sets the private variable for the player  from the parameter name
            Password = pPassword,
            LocationId = pLocationId,
            Health = pHealth,
            Wealth = pWealth,
            X = pX,
            Y = pY

        };
        _connection.Insert(player);
        return player;
    }
  
    public void  storePlayer(Player pPlayer, float pX, float pY) // WORKS 8)
    {
        pPlayer.X = pX;
        pPlayer.Y = pY;
           
        _connection.InsertOrReplace(pPlayer);

    }
    
    public Player getPlayer(string pPlayerName)// Method with a where clause to retrieve the player name
    {
        return _connection.Table<Player>().Where(x => x.Name == pPlayerName).FirstOrDefault();
 
    }

   
    //public Player getAllPlayer(float pX)// Method with a where clause to retrieve the player name
    //{
    //    return _connection.Table<Player>().Where(x=> x.X == pX).FirstOrDefault();

    //}

  

   


}
