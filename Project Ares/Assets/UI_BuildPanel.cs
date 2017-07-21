using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BuildPanel : MonoBehaviour
{
    public void BuildButtonPanel(GameObject previewPrefab)
    {
        Instantiate(previewPrefab);
    }
}
