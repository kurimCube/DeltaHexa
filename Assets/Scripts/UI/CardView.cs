using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カード表示・選択処理（Phase1）
/// - カード表示
/// - 選択処理
/// </summary>
public class CardView : MonoBehaviour
{
    private CardInstance cardInstance;
    private CardManager cardManager;
    private Button button;

    private Color normalColor = Color.white;
    private Color selectedColor = Constants.SELECTED_CARD_COLOR;

    public void Initialize(CardInstance card, CardManager cManager)
    {
        cardInstance = card;
        cardManager = cManager;
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnClicked);
        }
    }

    private void OnClicked()
    {
        if (cardInstance != null && cardManager != null)
        {
            cardManager.SelectCard(cardInstance);
            UpdateVisuals();
        }
    }

    /// <summary>
    /// 選択状態に応じた見た目更新
    /// </summary>
    public void UpdateVisuals()
    {
        if (button != null && cardManager != null)
        {
            bool isSelected = (cardManager.GetSelectedCard() == cardInstance);
            Image image = button.GetComponent<Image>();
            if (image != null)
            {
                image.color = isSelected ? selectedColor : normalColor;
            }
        }
    }
}
