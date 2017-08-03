using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tile is a class which stores data about each tile. 
/// </summary>
public class Tile 
{
    // X and Y are readonly because a tile shouldn't be moved around after it's created
    public readonly int X;
    public readonly int Y;
    // Tiles keep a reference to the world
    public readonly World World;

    private PlaceableObject _placedObject;
    public PlaceableObject PlacedObject
    {
        get
        {
            return _placedObject;
        }
        set
        {
            _placedObject = value;
            if (OnObjectPlaced != null)
                OnObjectPlaced(PlacedObject);
        }
    }
    public event Action<PlaceableObject> OnObjectPlaced;
    // A few things for later
    /*
     * Room
     * Air Pressure
     * Temperature
     * Craters?
     * Buildings - Or just generic residential/commericial/industrial labels?
     */ 


    public Tile(int x, int y, World world)
    {
        X = x;
        Y = y;
        World = world;
    }

    public override string ToString()
    {
        return "Tile " + X.ToString() + "_" + Y.ToString();
    }
}
