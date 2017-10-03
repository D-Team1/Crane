using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの制御クラス(シングルトン)
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 唯一のインスタンス
    /// </summary>
    static GameManager instance;
    public GameManager Instance {
        get {
            if (instance == null) {
                instance = new GameManager();
            }

            return instance;
        }
    }

    private static int stageNum = 0;
    public static int StageNum {
        get {
            return stageNum;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            gameClear();
        }
    }

    public static void changeStage(int _stageNum)
    {
        stageNum = _stageNum;
        SceneManager.changeScene(SceneNames.Main);
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
