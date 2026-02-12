using UnityEngine;

/// <summary>
/// 戦闘中の敵状態
/// </summary>
public class EnemyInstance
{
    public EnemyData data;
    public int currentHp;

    public EnemyInstance(EnemyData enemyData)
    {
        data = enemyData;
        currentHp = enemyData.maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    public bool IsDefeated()
    {
        return currentHp <= 0;
    }
}
