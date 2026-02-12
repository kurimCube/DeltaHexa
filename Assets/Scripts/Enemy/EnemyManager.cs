using UnityEngine;

/// <summary>
/// 敵行動処理
/// ダメージ受理
/// </summary>
public class EnemyManager : MonoBehaviour
{
    private EnemyInstance enemy;

    private void Start()
    {
        // 敵データを初期化
    }

    public void Initialize(EnemyData enemyData)
    {
        enemy = new EnemyInstance(enemyData);
    }

    public void ReceiveDamage(int damage)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    public void PerformAction()
    {
        // 敵行動処理
    }

    public EnemyInstance GetEnemy()
    {
        return enemy;
    }
}
