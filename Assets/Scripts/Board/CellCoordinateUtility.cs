using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 三角形グリッド座標ユーティリティ
/// Axial座標システムを管理
/// |x| + |y| + |(-x - y)| <= 4 の制約を満たす座標を生成・検証
/// </summary>
public static class CellCoordinateUtility
{
    /// <summary>
    /// 制約式を満たすかチェック
    /// |x| + |y| + |(-x - y)| <= 4
    /// </summary>
    public static bool IsValidCoordinate(Vector2Int coord)
    {
        int x = coord.x;
        int y = coord.y;
        int z = -x - y;

        return Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z) <= 4;
    }

    /// <summary>
    /// 全有効座標を生成
    /// 総数24マス
    /// </summary>
    public static List<Vector2Int> GenerateAllValidCoordinates()
    {
        List<Vector2Int> coords = new List<Vector2Int>();

        for (int x = -4; x <= 4; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                if (IsValidCoordinate(new Vector2Int(x, y)))
                {
                    coords.Add(new Vector2Int(x, y));
                }
            }
        }

        return coords;
    }

    /// <summary>
    /// 座標をワールド座標に変換（将来用）
    /// Phase1では仮実装
    /// </summary>
    public static Vector3 CoordinateToWorldPosition(Vector2Int coord, float cellSize = 1.0f)
    {
        // 正三角形グリッドのレイアウト変換
        float x = cellSize * (3.0f / 2.0f) * coord.x;
        float y = cellSize * (Mathf.Sqrt(3.0f) / 2.0f * coord.x + Mathf.Sqrt(3.0f) * coord.y);

        return new Vector3(x, y, 0);
    }

    /// <summary>
    /// ワールド座標から座標に変換（将来用）
    /// Phase1では仮実装
    /// </summary>
    public static Vector2Int WorldPositionToCoordinate(Vector3 worldPos, float cellSize = 1.0f)
    {
        // 逆変換
        float x = (2.0f / 3.0f) * worldPos.x / cellSize;
        float y = (-1.0f / 3.0f) * worldPos.x / cellSize + (Mathf.Sqrt(3.0f) / 3.0f) * worldPos.y / cellSize;

        return new Vector2Int(Mathf.RoundToInt(x), Mathf.RoundToInt(y));
    }
}
