using UnityEngine;

/// <summary>
/// 戦闘中のカード状態
/// </summary>
public class CardInstance
{
    public CardData data;
    public int currentPower;

    public CardInstance(CardData cardData)
    {
        data = cardData;
        currentPower = cardData.basePower;
    }
}
