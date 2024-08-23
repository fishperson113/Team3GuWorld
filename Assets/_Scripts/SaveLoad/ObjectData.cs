using System;
using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public string objectID;
    public float[] position;
    public float[] rotation;
    public bool isActive;

    public ObjectData(string id, Vector3 pos, Quaternion rot, bool active)
    {
        objectID = id;
        position = new float[] { pos.x, pos.y, pos.z };
        rotation = new float[] { rot.eulerAngles.x, rot.eulerAngles.y, rot.eulerAngles.z };
        isActive = active;
    }
}