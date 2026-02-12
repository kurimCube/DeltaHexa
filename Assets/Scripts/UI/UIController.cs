using UnityEngine;

/// <summary>
/// UI全体制御
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private HandView handView;
    [SerializeField] private HPBarView playerHPBar;
    [SerializeField] private HPBarView enemyHPBar;

    private void Start()
    {
        // UI初期化
    }

    public void UpdateUI()
    {
        // UI更新
    }
}
