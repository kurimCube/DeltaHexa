using UnityEngine;

/// <summary>
/// カードUI表示
/// クリック処理（Managerへ通知）
/// </summary>
public class CardView : MonoBehaviour
{
    private CardInstance cardData;

    public void Initialize(CardInstance card)
    {
        cardData = card;
    }

    private void OnMouseDown()
    {
        // CardManagerへ通知
    }
}
