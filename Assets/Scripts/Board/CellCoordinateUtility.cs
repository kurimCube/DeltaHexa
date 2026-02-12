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
        // 三角格子向け変換:
        // 基底ベクトル v1=(1,0), v2=(0.5, sqrt(3)/2) を使う線形写像
        // world = cellSize * (coord.x * v1 + coord.y * v2)
        float a = cellSize;
        float x = a * (coord.x + 0.5f * coord.y);
        float y = a * (Mathf.Sqrt(3.0f) / 2.0f * coord.y);

        return new Vector3(x, y, 0f);
    }

    /// <summary>
    /// ワールド座標から座標に変換（将来用）
    /// Phase1では仮実装
    /// </summary>
    public static Vector2Int WorldPositionToCoordinate(Vector3 worldPos, float cellSize = 1.0f)
    {
        // 上の線形写像の逆変換（近似、四捨五入で格子点へ）
        float a = cellSize;
        float yf = worldPos.y / (a * (Mathf.Sqrt(3.0f) / 2.0f));
        float xf = worldPos.x / a - 0.5f * yf;

        int xi = Mathf.RoundToInt(xf);
        int yi = Mathf.RoundToInt(yf);

        return new Vector2Int(xi, yi);
    }

    /// <summary>
    /// TriangleCoord 用のオーバーロード
    /// </summary>
    public static bool IsValidCoordinate(TriangleCoord coord)
    {
        return IsValidCoordinate(coord.Pos);
    }

    public static List<TriangleCoord> GenerateAllValidTriangleCoordinates()
    {
        List<TriangleCoord> list = new List<TriangleCoord>();
        for (int x = -4; x <= 4; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                Vector2Int v = new Vector2Int(x, y);
                if (IsValidCoordinate(v))
                {
                    bool isUp = (x + y) % 2 == 0;
                    list.Add(new TriangleCoord(v, isUp));
                }
            }
        }
        return list;
    }

    public static Vector3 CoordinateToWorldPosition(TriangleCoord coord, float cellSize = 1.0f)
    {
        return CoordinateToWorldPosition(coord.Pos, cellSize);
    }

    public static TriangleCoord WorldPositionToTriangleCoordinate(Vector3 worldPos, float cellSize = 1.0f)
    {
        Vector2Int v = WorldPositionToCoordinate(worldPos, cellSize);
        bool isUp = (v.x + v.y) % 2 == 0;
        return new TriangleCoord(v, isUp);
    }
}
