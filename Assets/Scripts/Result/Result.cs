using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リザルトシーンの制御クラス
/// </summary>
public class Result : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.changeScene(SceneNames.Title);
        }
    }
}
