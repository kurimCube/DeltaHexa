using UnityEngine;

/// <summary>
/// 拡張メソッド
/// </summary>
public static class Extensions
{
    public static Vector2Int ToVector2Int(this Vector3 vector)
    {
        return new Vector2Int((int)vector.x, (int)vector.y);
    }

    public static Vector3 ToVector3(this Vector2Int vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }
}
