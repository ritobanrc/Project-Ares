using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TileUnderMouse : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    private void LateUpdate()
    {
        Tile underMouse = MouseController.Instance.tileUnderMouse;
        if (underMouse != null)
        {
            string text = "Tile\n";
            text += "X: " + underMouse.X + "\n";
            text += "Y: " + underMouse.Y + "\n";
            text += "Room: Dome 1 \nAir Pressure: 1.3 atmo \n";
            textMesh.text = text;
        }
        else
        {
            textMesh.text = string.Empty;
        }
    }
}
