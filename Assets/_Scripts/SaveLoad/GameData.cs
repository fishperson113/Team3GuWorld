using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public float[] playerPosition;
    public List<ObjectData> objectsData = new List<ObjectData>();
}
