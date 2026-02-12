using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 手札表示制御（Phase1）
/// - CardManager.handを元にUI再生成
/// - Refresh()で再描画
/// </summary>
public class HandView : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    [SerializeField] private GameObject cardViewPrefab;
    [SerializeField] private Transform handContainer;

    public void Initialize()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (cardManager == null || handContainer == null)
            return;

        // 既存UIをクリア
        foreach (Transform child in handContainer)
        {
            Destroy(child.gameObject);
        }

        // 手札分のCardViewを生成
        List<CardInstance> hand = cardManager.GetHand();
        foreach (CardInstance card in hand)
        {
            if (cardViewPrefab != null)
            {
                GameObject cardViewObj = Instantiate(cardViewPrefab, handContainer);
                CardView cardView = cardViewObj.GetComponent<CardView>();
                if (cardView != null)
                {
                    cardView.Initialize(card, cardManager);
                }
            }
        }
    }
}
