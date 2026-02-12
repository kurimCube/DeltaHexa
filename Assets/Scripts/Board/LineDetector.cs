using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// 直線完成判定ロジック
/// 判定専用クラスとして分離
/// </summary>
public class LineDetector : MonoBehaviour
{
    public bool CheckLine(TriangleCoord position, Dictionary<TriangleCoord, Cell> cells)
    {
        // 3方向チェック（横、縦、斜め）
        return CheckHorizontal(position, cells) ||
               CheckVertical(position, cells) ||
               CheckDiagonal(position, cells);
    }

    private bool CheckHorizontal(TriangleCoord position, Dictionary<TriangleCoord, Cell> cells)
    {
        // 横方向のライン判定
        return false; // TODO: 実装
    }

    private bool CheckVertical(TriangleCoord position, Dictionary<TriangleCoord, Cell> cells)
    {
        // 縦方向のライン判定
        return false; // TODO: 実装
    }

    private bool CheckDiagonal(TriangleCoord position, Dictionary<TriangleCoord, Cell> cells)
    {
        // 斜め方向のライン判定
        return false; // TODO: 実装
    }
}
