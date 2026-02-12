using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// シャッフル
/// カード追加削除
/// </summary>
public class Deck : MonoBehaviour
{
    private List<CardData> deckList = new List<CardData>();

    public void Initialize(List<CardData> cards)
    {
        deckList = new List<CardData>(cards);
        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = deckList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            CardData temp = deckList[i];
            deckList[i] = deckList[randomIndex];
            deckList[randomIndex] = temp;
        }
    }

    public CardInstance DrawCard()
    {
        if (deckList.Count == 0)
            return null;

        CardData data = deckList[0];
        deckList.RemoveAt(0);
        return new CardInstance(data);
    }

    public void AddCard(CardData card)
    {
        deckList.Add(card);
    }

    public void RemoveCard(CardData card)
    {
        deckList.Remove(card);
    }
}
