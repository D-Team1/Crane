using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルシーンの制御クラス
/// </summary>
public class Title : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.changeScene(SceneNames.StageSelect);
        }
    }
}
