using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// デッキ管理
/// 手札管理
/// ドロー処理
/// カード使用処理
/// </summary>
public class CardManager : MonoBehaviour
{
    private Deck deck;
    private List<CardInstance> hand = new List<CardInstance>();

    private void Start()
    {
        deck = GetComponent<Deck>();
    }

    public void DrawCard()
    {
        CardInstance card = deck.DrawCard();
        if (card != null)
        {
            hand.Add(card);
        }
    }

    public bool UseCard(CardInstance card, Vector2Int position)
    {
        if (!hand.Contains(card))
            return false;

        // カード使用処理
        hand.Remove(card);
        return true;
    }

    public List<CardInstance> GetHand()
    {
        return new List<CardInstance>(hand);
    }
}
