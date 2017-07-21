using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : Singleton<WorldController>
{
    public int mapWidth = 100;
    public int mapHeight = 100;

    public World World { get; protected set; }

    private WorldView worldView;
    private BidirectionalDictionary<Tile, GameObject> tileGameObjectMap;

    private void Awake()
    {
        World = new World(mapWidth, mapHeight);
        tileGameObjectMap = new BidirectionalDictionary<Tile, GameObject>();
        // Now, inform the WorldView that this world has been created. 
        worldView = GetComponent<WorldView>();
        worldView.TileGameObjectUpdated += WorldView_TileGameObjectUpdated;
        worldView.SetupInitialWorld(World);
    }

    private void WorldView_TileGameObjectUpdated(Tile t, GameObject go)
    {
        if(tileGameObjectMap.ContainsKey(t) == false)
        {
            // In this case, the gameobject was just created.
            tileGameObjectMap.Add(t, go);
        }
    }

    public Tile GetTileAt(int i, int j)
    {
        return World.GetTileAt(i, j);
    }

    public GameObject GetGameObjectForTile(Tile t)
    {
        return tileGameObjectMap[t];
    }

    public Tile GetTileForGameObject(GameObject go)
    {
        return tileGameObjectMap[go];
    }
}
