using UnityEngine;

/// <summary>
/// ScriptableObject
/// カード定義データ
/// - 名前
/// - 形状
/// - 属性
/// - 基礎威力
/// </summary>
[CreateAssetMenu(fileName = "New Card Data", menuName = "DeltaHexa/Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string cardShape; // TODO: 形状の定義
    public string attribute; // TODO: 属性の定義
    public int basePower;
}
