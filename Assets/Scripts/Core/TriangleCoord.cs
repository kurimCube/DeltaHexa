using UnityEngine;
using System;

/// <summary>
/// 三角形座標の向きと位置
/// </summary>
[Serializable]
public struct TriangleCoord : IEquatable<TriangleCoord>
{
    public Vector2Int Pos;
    public bool IsUp;

    public TriangleCoord(int x, int y, bool isUp)
    {
        Pos = new Vector2Int(x, y);
        IsUp = isUp;
    }

    public TriangleCoord(Vector2Int pos, bool isUp)
    {
        Pos = pos;
        IsUp = isUp;
    }

    public bool Equals(TriangleCoord other)
    {
        return Pos.Equals(other.Pos) && IsUp == other.IsUp;
    }

    public override bool Equals(object obj)
    {
        return obj is TriangleCoord other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + Pos.GetHashCode();
            hash = hash * 31 + (IsUp ? 1 : 0);
            return hash;
        }
    }

    public override string ToString()
    {
        return $"({Pos.x},{Pos.y}) up={IsUp}";
    }
}
