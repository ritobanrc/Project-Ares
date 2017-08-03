using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObjectsView : Singleton<PlaceableObjectsView>
{
    private void Awake()
    {
        BuildController.Instance.OnAnyObjectPlaced += BuildController_OnAnyObjectPlaced;
    }

    private void BuildController_OnAnyObjectPlaced(PlaceableObject obj)
    {
        GameObject objGo = new GameObject(obj.Name + " " + obj.Tile.ToString());
        GameObject GFX = new GameObject("GFX");
        GFX.transform.SetParent(objGo.transform);
        SpriteRenderer sr = GFX.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(obj.Data.IconPath);
        objGo.transform.SetParent(WorldController.Instance.GetGameObjectForTile(obj.Tile).transform, false);
    }
}
