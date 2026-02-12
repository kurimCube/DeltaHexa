using UnityEngine;

/// <summary>
/// ScriptableObject
/// 敵の基礎データ
/// </summary>
[CreateAssetMenu(fileName = "New Enemy Data", menuName = "DeltaHexa/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public int baseDamage;
    public string behavior; // TODO: 行動パターンの定義
}
