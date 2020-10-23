using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Player  // the player class
{
    // each private element  regarding the player
    private string name;
    private string password;
    private int location;
    private int health;
    private int wealth;
    private  int hi_score;

    // what about inventory?
    [PrimaryKey, AutoIncrement] // declairs the primary key and sets its state to increment
    // public properties for each of the private elements so that other classes can have access to the private elements
    public int PlayerID { get ; set ; }
    public string Name { get => name; set => name = value; }
    public string Password { get => password; set => password = value; }
    public int  LocationId { get => location; set => location = value; }
    public int Health { get => health; set => health = value; }
    public int Wealth { get => wealth; set => wealth = value; }
    public int HiScore { get => hi_score; set => hi_score = value; }
    public float X { get; set; }
    public float Y { get; set; }
 
    // Not sure if these methods are needed anymore
  //  public Vector2 GetTransform() {
  //      Vector2 result;
  //      result.x = X;
  //      result.y = Y;
  //      return result;

  //  }
  //public void SetTransform()
  //  {

  //  }
}
