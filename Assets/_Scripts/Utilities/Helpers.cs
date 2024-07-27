using UnityEngine;

/// <summary>
/// A static class for general helpful methods
/// </summary>
public static class Helpers 
{
    
    public static void DestroyChildren(this Transform t) {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }
    public static Vector2 CalculateDirection(Vector2 firstPosition, Vector2 secondPosition)
    {
        Vector2 direction = (firstPosition - secondPosition).normalized;
        return direction;
    }
    
}
