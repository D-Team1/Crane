using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの制御クラス(シングルトン)
/// </summary>
public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public GameManager Instance {
        get {
            if (instance == null) {
                instance = new GameManager();
            }

            return instance;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            gameClear();
        }
    }

    /// <summary>
    /// クリア時の処理
    /// </summary>
    public void gameClear()
    {
        //TODO: クリア時の処理
        SceneManager.changeScene(SceneNames.Result);
    }

    /// <summary>
    /// ゲームオーバー時の処理
    /// </summary>
    public void gameOver()
    {
        //TODO: ゲームオーバーの際の処理
    }
}
