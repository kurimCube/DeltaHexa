using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 24セル生成処理
/// </summary>
public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private int width = 6;
    [SerializeField] private int height = 4;
    [SerializeField] private float cellSize = 1.0f;

    private List<Cell> generatedCells = new List<Cell>();

    public List<Cell> GenerateBoard()
    {
        generatedCells.Clear();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector2Int position = new Vector2Int(x, y);
                Cell cell = new Cell(position);
                generatedCells.Add(cell);
            }
        }

        return generatedCells;
    }
}
