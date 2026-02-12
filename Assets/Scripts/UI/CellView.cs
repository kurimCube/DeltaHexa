using UnityEngine;

/// <summary>
/// セル表示・クリック処理（Phase1）
/// - マス表示
/// - クリック受付
/// - 占有状態の可視化
/// </summary>
public class CellView : MonoBehaviour
{
    private Cell cellData;
    private BoardManager boardManager;
    private CardManager cardManager;
    private SpriteRenderer spriteRenderer;

    private Color emptyColor = Constants.EMPTY_CELL_COLOR;
    private Color occupiedColor = Constants.OCCUPIED_CELL_COLOR;

    public void Initialize(Cell cell, BoardManager bManager)
    {
        cellData = cell;
        boardManager = bManager;
        cardManager = FindObjectOfType<CardManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (cellData == null || cardManager == null)
            return;

        // 選択中のカードで配置試行
        if (cardManager.UseSelectedCard(cellData.coordinate))
        {
            UpdateVisuals();
        }
    }

    /// <summary>
    /// 占有状態に応じた見た目更新
    /// </summary>
    public void UpdateVisuals()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = cellData.isOccupied ? occupiedColor : emptyColor;
        }
    }
}
