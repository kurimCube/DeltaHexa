using UnityEngine;

/// <summary>
/// ダメージ計算処理分離
/// 基本式（MVP）: 最終ダメージ = 基礎威力合計
/// </summary>
public class DamageCalculator : MonoBehaviour
{
    public int CalculateDamage(int basePowerSum)
    {
        // MVP段階では単純計算
        return basePowerSum;
    }

    // 将来拡張用
    public int CalculateDamageWithModifiers(int basePowerSum, float attributeBonus, float relicMultiplier)
    {
        return (int)((basePowerSum + attributeBonus) * relicMultiplier);
    }
}
