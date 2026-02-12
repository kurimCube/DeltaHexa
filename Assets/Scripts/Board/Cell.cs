using UnityEngine;

/// <summary>
/// セルデータ構造
/// - 座標
/// - 占有状態
/// - 配置カード参照
/// </summary>
public class Cell
{
    public Vector2Int coordinate;
    public bool isOccupied;
    public CardInstance placedCard;
    public bool isBlocked;

    public Cell(Vector2Int coord)
    {
        coordinate = coord;
        isOccupied = false;
        placedCard = null;
        isBlocked = false;
    }

    public void PlaceCard(CardInstance card)
    {
        placedCard = card;
        isOccupied = true;
    }

    public void RemoveCard()
    {
        placedCard = null;
        isOccupied = false;
    }
}
