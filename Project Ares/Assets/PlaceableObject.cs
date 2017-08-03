using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject
{
    public PlaceableObjectData Data { get; protected set; }
    public string Name
    {
        get
        {
            return Data.Name;
        }
    }

    public readonly Tile Tile;

    public PlaceableObject(PlaceableObjectData data, Tile tile)
    {
        Data = data;
        Tile = tile;
    }

    public override string ToString()
    {
        return Name;
    }
}
