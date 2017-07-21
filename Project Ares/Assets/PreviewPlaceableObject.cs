using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewPlaceableObject : MonoBehaviour
{
    private void Update()
    {
        // FIXME: set this up with the mouse controller, so that if you are placing something, you don't drag the mouse! 
        if (Input.GetMouseButtonUp(0))
        {
            // FIXME: Integrate this with the buildcontroller
            Destroy(this);
        }
        this.transform.position = WorldController.Instance.GetGameObjectForTile(MouseController.Instance.tileUnderMouse).transform.position;
    }
}
