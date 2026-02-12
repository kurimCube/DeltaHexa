using UnityEngine;

/// <summary>
/// ゲーム全体管理（Phase1初期化のみ）
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private BoardManager boardManager;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private UIController uiController;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // 初期化フロー
        if (boardManager != null)
        {
            boardManager.Initialize();
        }

        if (cardManager != null)
        {
            cardManager.Initialize();
        }

        if (uiController != null)
        {
            uiController.Initialize();
        }
    }
}
