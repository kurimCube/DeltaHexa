using UnityEngine;

/// <summary>
/// ScriptableObject - カード定義データ（Phase1簡易版）
/// - 名前
/// - アイコン
/// </summary>
[CreateAssetMenu(fileName = "New Card Data", menuName = "DeltaHexa/Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite icon;

    // Phase2以降で追加予定
    // public int power;
    // public string cardShape;
    // public string attribute;
}
