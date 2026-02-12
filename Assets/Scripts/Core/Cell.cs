using UnityEngine;

/// <summary>
/// セルデータ構造（Phase1最小構成）
/// - 座標
/// - 占有状態
/// - 配置カード参照
/// ロジックは持たない（データのみ）
/// </summary>
public class Cell
{
    public Vector2Int coordinate;
    public bool isOccupied;
    public CardInstance placedCard;

    public Cell(Vector2Int coord)
    {
        coordinate = coord;
        isOccupied = false;
        placedCard = null;
    }
}
