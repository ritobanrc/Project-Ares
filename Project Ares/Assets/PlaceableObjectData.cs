using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class PlaceableObjectData
{
    // FIXME: should be readonly once we set it up with the xml data file. For now, unity's serializer doesn't work with readonly values
    public string Name;
    public string IconPath;

    public PlaceableObjectData(string name, string iconPath)
    {
        Name = name;
        IconPath = iconPath;
    }
}
