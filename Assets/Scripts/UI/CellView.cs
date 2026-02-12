using UnityEngine;

/// <summary>
/// セル描画
/// 選択通知
/// </summary>
public class CellView : MonoBehaviour
{
    private Cell cellData;

    public void Initialize(Cell cell)
    {
        cellData = cell;
    }

    private void OnMouseDown()
    {
        // BoardManagerへ選択通知
    }
}
