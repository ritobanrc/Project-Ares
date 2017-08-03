using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewPlaceableObject : MonoBehaviour
{
    public PlaceableObjectData Data;

    private void Start()
    {
        BuildController.Instance.AddPlaceableObject(this);
    }

    public event Action<PlaceableObjectData> OnObjectPlaced;

    private void Update()
    {
        // FIXME: set this up with the mouse controller, so that if you are placing something, you don't drag the mouse! 
        if (Input.GetMouseButtonUp(0))
        {
            // FIXME: Integrate this with the buildcontroller
            if (OnObjectPlaced != null)
                OnObjectPlaced(Data);
            Destroy(this.gameObject);
        }
        this.transform.position = WorldController.Instance.GetGameObjectForTile(MouseController.Instance.TileUnderMouse).transform.position;
    }
}
