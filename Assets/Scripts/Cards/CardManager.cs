using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// カード管理（Phase1）
/// - 手札生成
/// - 現在選択中カード管理
/// - カード配置処理
/// </summary>
public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardData> initialCards = new List<CardData>();
    [SerializeField] private BoardManager boardManager;

    private List<CardInstance> hand = new List<CardInstance>();
    private CardInstance selectedCard = null;

    public void Initialize()
    {
        // Phase1: 仮カード3枚を生成
        hand.Clear();
        for (int i = 0; i < Mathf.Min(Constants.INITIAL_HAND_SIZE, initialCards.Count); i++)
        {
            if (initialCards[i] != null)
            {
                hand.Add(new CardInstance(initialCards[i]));
            }
        }
    }

    /// <summary>
    /// カード選択
    /// </summary>
    public void SelectCard(CardInstance card)
    {
        selectedCard = card;
    }

    /// <summary>
    /// 選択中のカードを配置
    /// </summary>
    public bool UseSelectedCard(Vector2Int coord)
    {
        if (selectedCard == null || boardManager == null)
            return false;

        // 配置可能判定
        if (!boardManager.CanPlace(coord))
            return false;

        // 配置実行
        if (boardManager.PlaceCard(coord, selectedCard))
        {
            // 手札から削除
            hand.Remove(selectedCard);
            selectedCard = null;
            return true;
        }

        return false;
    }

    /// <summary>
    /// 現在の手札取得
    /// </summary>
    public List<CardInstance> GetHand()
    {
        return new List<CardInstance>(hand);
    }

    /// <summary>
    /// 選択中のカード取得
    /// </summary>
    public CardInstance GetSelectedCard()
    {
        return selectedCard;
    }
}
