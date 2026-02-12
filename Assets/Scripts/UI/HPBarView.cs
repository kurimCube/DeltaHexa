using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// HP表示更新
/// </summary>
public class HPBarView : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private Text hpText;

    public void UpdateHP(int current, int max)
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = (float)current / max;
        }

        if (hpText != null)
        {
            hpText.text = $"{current}/{max}";
        }
    }
}
