using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class RegisterPlayer : MonoBehaviour

{
  
    // public GameObject player_Name;
    public InputField user_name;
    public InputField password;

    // Start is called before the first frame update
    void Start()
    {
        
        ReadData();
    }
     public void InputData() {
        string dbLogin = "URI=file:" + Application.dataPath + "/ShadowOfRonnin.sqlite";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(dbLogin);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO Login(user_name , password) VALUES(' " + user_name.text+ " ' ,' " + password.text+" ');";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;


    }
   void ReadData()
    {
        string dbLogin = "URI=file:" + Application.dataPath + "/ShadowOfRonnin.sqlite";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(dbLogin);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT ID,user_name,password " + "FROM Login";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int ID = reader.GetInt32(0);
            string user_name = reader.GetString(1);
            string password = reader.GetString(2);

           // player_Name.GetComponent<Text>().text = user_name;

        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

  
}

