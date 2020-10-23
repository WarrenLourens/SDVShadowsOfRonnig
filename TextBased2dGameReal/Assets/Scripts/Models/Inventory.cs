using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private string name;
    private string description;
    private int points;

    [PrimaryKey, AutoIncrement]
    public int ItemID { get; set; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public int Points { get => points; set => points = value; }
}
