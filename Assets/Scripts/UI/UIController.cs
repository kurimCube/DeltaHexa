using UnityEngine;

/// <summary>
/// UI全体制御（Phase1最小構成）
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private HandView handView;
    [SerializeField] private CardManager cardManager;

    public void Initialize()
    {
        if (handView != null && cardManager != null)
        {
            handView.Initialize();
        }
    }
}
