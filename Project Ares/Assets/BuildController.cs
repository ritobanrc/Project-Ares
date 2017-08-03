using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : Singleton<BuildController>
{
    public HashSet<PreviewPlaceableObject> PlaceableObjectPreviews { get; protected set; }
    public HashSet<PlaceableObject> PlacedObjects { get; protected set; }

    private void Awake()
    {
        PlaceableObjectPreviews = new HashSet<PreviewPlaceableObject>();
        PlacedObjects = new HashSet<PlaceableObject>();
    }

    public event Action<PlaceableObject> OnAnyObjectPlaced;

    public void AddPlaceableObject(PreviewPlaceableObject previewPlaceableObject)
    {
        PlaceableObjectPreviews.Add(previewPlaceableObject);
        previewPlaceableObject.OnObjectPlaced += PreviewPlaceableObject_OnObjectPlaced;
    }

    private void PreviewPlaceableObject_OnObjectPlaced(PlaceableObjectData objectDataToPlace)
    {
        Tile tileToPlaceOn = MouseController.Instance.TileUnderMouse;
        if(tileToPlaceOn.PlacedObject != null)
        {
            Debug.LogWarning("This tile is already occupied!");
            return;
        }
        PlaceableObject placeableObject = new PlaceableObject(objectDataToPlace, tileToPlaceOn);
        
        PlacedObjects.Add(placeableObject);
        tileToPlaceOn.PlacedObject = placeableObject;
        if (OnAnyObjectPlaced != null)
            OnAnyObjectPlaced(placeableObject);
    }
}
