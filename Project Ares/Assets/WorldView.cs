﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldView : MonoBehaviour
{
    public Sprite[] BaseTileSprites;
    public string BackgroundSortingLayerName = "Background";

    public event Action<Tile, GameObject> TileGameObjectUpdated; 


    public void SetupInitialWorld(World world)
    {
        Tile[,] worldMap = world.WorldMap;
        for (int i = 0; i < world.MapWidth; i++)
        {
            for (int j = 0; j < world.MapHeight; j++)
            {
                Tile tile = worldMap[i, j];
                GameObject tileGo = new GameObject(tile.ToString());
                tileGo.transform.SetParent(this.transform);
                tileGo.transform.position = new Vector3(i, j);
                SpriteRenderer sr = tileGo.AddComponent<SpriteRenderer>();
                sr.sprite = BaseTileSprites[UnityEngine.Random.Range(0, BaseTileSprites.Length)];
                sr.sortingLayerName = BackgroundSortingLayerName;
                if (TileGameObjectUpdated != null)
                    TileGameObjectUpdated(tile, tileGo);
            }
        }
    }
}
