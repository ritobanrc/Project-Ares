using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World 
{
    public Tile[,] WorldMap { get; protected set; }
    public int MapWidth
    {
        get
        {
            return WorldMap.GetLength(0);
        }
    }
    public int MapHeight
    {
        get
        {
            return WorldMap.GetLength(1);
        }
    }

    public World(int mapWidth, int mapHeight)
    {
        WorldMap = new Tile[mapWidth, mapHeight];

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                WorldMap[i, j] = new Tile(i, j, this);
            }
        }
    }


    public Tile GetTileAt(int i, int j)
    {
        if(i < 0 || i >= MapWidth || j < 0 || j >= MapHeight)
        {
            return null;
        }
        return WorldMap[i, j];
    }
}
