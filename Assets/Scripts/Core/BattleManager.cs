using UnityEngine;

/// <summary>
/// ターン管理
/// 勝敗判定
/// 状態遷移管理
/// </summary>
public class BattleManager : MonoBehaviour
{
    public BattleState CurrentState { get; private set; } = BattleState.PlayerTurn;

    // Managers
    private BoardManager boardManager;
    private CardManager cardManager;
    private EnemyManager enemyManager;
    private EffectResolver effectResolver;

    private void Awake()
    {
        boardManager = GetComponent<BoardManager>();
        cardManager = GetComponent<CardManager>();
        enemyManager = GetComponent<EnemyManager>();
        effectResolver = GetComponent<EffectResolver>();
    }

    public void ChangeState(BattleState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case BattleState.PlayerTurn:
                OnPlayerTurnStart();
                break;
            case BattleState.EnemyTurn:
                OnEnemyTurnStart();
                break;
            case BattleState.Win:
                OnWin();
                break;
            case BattleState.Lose:
                OnLose();
                break;
        }
    }

    private void OnPlayerTurnStart()
    {
        // プレイヤーターン開始処理
    }

    private void OnEnemyTurnStart()
    {
        // 敵ターン開始処理
    }

    private void OnWin()
    {
        // 勝利処理
    }

    private void OnLose()
    {
        // 敗北処理
    }
}
