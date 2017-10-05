using UnityEngine;

/// <summary>
/// ボタンのイベント毎のサウンド
/// </summary>
public class ButtonSoundEvent : MonoBehaviour
{
    /// <summary>
    /// クリックイベント時の音
    /// </summary>
    public void OnClick()
    {
        SoundManager.Instance.playOverapSE(0);
    }

    public void Select()
    {
        SoundManager.Instance.playOverapSE(1);
    }
}
