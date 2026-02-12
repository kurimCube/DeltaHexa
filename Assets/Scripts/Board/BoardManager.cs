using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 盤面管理（Phase1）
/// - 三角グリッド生成
/// - セル管理
/// - 配置可否判定
/// - セル状態更新
/// </summary>
public class BoardManager : MonoBehaviour
{
    private Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>();

    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform boardRoot;

    public void Initialize()
    {
        // 座標生成
        List<Vector2Int> coordinates = GenerateCoordinates();

        // 各座標にCellを生成
        foreach (Vector2Int coord in coordinates)
        {
            Cell cell = new Cell(coord);
            cells[coord] = cell;

            // CellView生成（Prefabからインスタンス化）
            if (cellPrefab != null && boardRoot != null)
            {
                GameObject cellObj = Instantiate(cellPrefab, boardRoot);
                CellView cellView = cellObj.GetComponent<CellView>();
                if (cellView != null)
                {
                    cellView.Initialize(cell, this);
                }
            }
        }
    }

    /// <summary>
    /// Axial座標で制約を満たす座標を全生成
    /// CellCoordinateUtilityを使用
    /// </summary>
    public List<Vector2Int> GenerateCoordinates()
    {
        return CellCoordinateUtility.GenerateAllValidCoordinates();
    }

    /// <summary>
    /// 配置可能判定
    /// </summary>
    public bool CanPlace(Vector2Int coord)
    {
        return cells.ContainsKey(coord) && !cells[coord].isOccupied;
    }

    /// <summary>
    /// カード配置
    /// </summary>
    public bool PlaceCard(Vector2Int coord, CardInstance card)
    {
        if (!CanPlace(coord))
            return false;

        cells[coord].placedCard = card;
        cells[coord].isOccupied = true;
        return true;
    }

    /// <summary>
    /// セル取得
    /// </summary>
    public Cell GetCell(Vector2Int coord)
    {
        return cells.ContainsKey(coord) ? cells[coord] : null;
    }

    /// <summary>
    /// 盤面のセル数確認（テスト用）
    /// </summary>
    public int GetCellCount()
    {
        return cells.Count;
    }
}
