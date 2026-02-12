using UnityEngine;

/// <summary>
/// 共通定数（Phase1向け）
/// </summary>
public static class Constants
{
    // Board
    public const int GRID_RADIUS = 2; // Axial座標の制約値
    public const int TOTAL_CELLS = 24; // 三角グリッドの総マス数
    public const float CELL_SIZE = 1.0f;

    // Hand
    public const int INITIAL_HAND_SIZE = 3; // Phase1での初期手札枚数

    // Colors
    public static readonly Color EMPTY_CELL_COLOR = Color.white;
    public static readonly Color OCCUPIED_CELL_COLOR = Color.gray;
    public static readonly Color SELECTED_CARD_COLOR = Color.yellow;
}
