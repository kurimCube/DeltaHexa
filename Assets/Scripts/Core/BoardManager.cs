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
    private Dictionary<TriangleCoord, Cell> cells = new Dictionary<TriangleCoord, Cell>();

    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform boardRoot;

    /// <summary>
    /// 仮のInit
    /// </summary>
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        // 座標生成
        List<TriangleCoord> coordinates = GenerateTriangleCoordinates();

        // 各座標にCellを生成
        foreach (TriangleCoord coord in coordinates)
        {
            // TriangleCoord の Pos をキーにして Cell を作成・格納する
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

        Debug.Log("Generated Cells: " + cells.Count);
    }

    /// <summary>
    /// 三角形座標の生成
    /// </summary>
    public List<TriangleCoord> GenerateTriangleCoordinates()
    {
        // CellCoordinateUtility の定義に合わせて有効座標を全件取得する
        List<TriangleCoord> result = CellCoordinateUtility.GenerateAllValidTriangleCoordinates();
        Debug.Log("Triangle count: " + result.Count);
        return result;
    }

    // TriangleCoord is defined in Core/TriangleCoord.cs
    /// <summary>
    /// 配置可能判定
    /// </summary>
    public bool CanPlace(TriangleCoord coord)
    {
        return cells.ContainsKey(coord) && !cells[coord].isOccupied;
    }

    /// <summary>
    /// カード配置
    /// </summary>
    public bool PlaceCard(TriangleCoord coord, CardInstance card)
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
    public Cell GetCell(TriangleCoord coord)
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
