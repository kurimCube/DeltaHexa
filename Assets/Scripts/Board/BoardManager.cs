using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 盤面データ保持
/// セル取得
/// 配置可否判定
/// 発動トリガー呼び出し
/// </summary>
public class BoardManager : MonoBehaviour
{
    private Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>();
    private List<List<Vector2Int>> precomputedLines = new List<List<Vector2Int>>();

    private void Start()
    {
        // BoardGeneratorで生成される想定
    }

    public bool CanPlace(Vector2Int position)
    {
        if (!cells.ContainsKey(position))
            return false;

        return !cells[position].isOccupied;
    }

    public Cell GetCell(Vector2Int position)
    {
        return cells.ContainsKey(position) ? cells[position] : null;
    }

    public void PlaceCard(Vector2Int position, CardInstance card)
    {
        if (cells.ContainsKey(position))
        {
            cells[position].PlaceCard(card);
        }
    }
}
