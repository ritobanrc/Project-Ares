using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public int mapWidth = 100;
    public int mapHeight = 100;

    public World World { get; protected set; }

    private WorldView worldView;
    private void Awake()
    {
        World = new World(mapWidth, mapHeight);
        // Now, inform the WorldView that this world has been created. 
        worldView = GetComponent<WorldView>();
        worldView.SetupInitialWorld(World);
    }
}
