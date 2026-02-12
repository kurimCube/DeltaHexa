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
            Cell cell = new Cell(coord.Pos);
            cells[coord.Pos] = cell;

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
        List<TriangleCoord> result = new List<TriangleCoord>();

        int size = 2;

        for (int y = -size; y < size; y++)
        {
            int minX = Mathf.Max(-size, -y - size);
            int maxX = Mathf.Min(size - 1, -y + size - 1);

            for (int x = minX; x <= maxX; x++)
            {
                bool isUp = (x + y) % 2 == 0;
                result.Add(new TriangleCoord(x, y, isUp));
            }
        }

        Debug.Log("Triangle count: " + result.Count);
        return result;
    }

    /// <summary>
    /// 三角形座標の向きと位置
    /// </summary>
    public struct TriangleCoord
    {
        public Vector2Int Pos;
        public bool IsUp;

        public TriangleCoord(int x, int y, bool isUp)
        {
            Pos = new Vector2Int(x, y);
            IsUp = isUp;
        }
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
