﻿using UnityEngine;

/// <summary>
/// シーン遷移の管理クラス(シングルトン)
/// </summary>
public class MySceneManager : MonoBehaviour
{
    public static void changeScene(string sceneName)
    {
        if (FadeImage.IsDuringFade) { return; }
        FadeImage.fadeOut(sceneName);
    }
}
