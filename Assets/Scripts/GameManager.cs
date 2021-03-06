﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームの制御クラス(シングルトン)
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 唯一のインスタンス
    /// </summary>
    public static GameManager Instance;

    /// <summary>
    /// ポーズ中に使用する再開ボタン
    /// </summary>
    [SerializeField]
    GameObject restartButton;

    /// <summary>
    /// ポーズ中に使用するタイトルへ移動するボタン
    /// </summary>
    [SerializeField]
    GameObject goToTitleButton;

    /// <summary>
    /// ゲームオーバー時に表示するテキスト
    /// </summary>
    [SerializeField]
    GameObject gameOverImage;

    /// <summary>
    /// ステージの番号
    /// </summary>
    static int stageNum = 1;
    public static int StageNum {
        get {
            return stageNum;
        }
    }

    /// <summary>
    /// ポーズ中か？
    /// </summary>
    bool isDuringPose = false;
    public bool IsDuringPose {
        get { return isDuringPose; }
    }

    /// <summary>
    /// ステージをクリア、もしくはゲームオーバになっているか
    /// </summary>
    bool isFinish = false;
    public bool IsFinish {
        get { return isFinish; }
    }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    void Start()
    {
        SoundManager.Instance.playBGM(0);
        restartButton.SetActive(false);
        goToTitleButton.SetActive(false);
        gameOverImage.SetActive(false);
    }

    void Update()
    {
        if (InputManager.pose()) {
            SoundManager.Instance.playOverapSE(0);
            if (Time.timeScale == 0) {
                restart();
            }
            else {
                pose();
            }
        }
    }

    /// <summary>
    /// ポーズ時の処理
    /// </summary>
    void pose()
    {
        isDuringPose = true;
        Time.timeScale = 0;
        restartButton.SetActive(true);
        goToTitleButton.SetActive(true);
        restartButton.GetComponent<Button>().Select();
    }

    /// <summary>
    /// 再開時の処理
    /// </summary>
    public void restart()
    {
        isDuringPose = false;
        Time.timeScale = 1;
        restartButton.SetActive(false);
        goToTitleButton.SetActive(false);
        goToTitleButton.GetComponent<Button>().Select();
    }

    /// <summary>
    /// ステージの変更の際に呼び出す
    /// </summary>
    /// <param name="_stageNum">呼び出したいステージ番号</param>
    public static void changeStage(int _stageNum)
    {
        stageNum = _stageNum;
        MySceneManager.changeScene(SceneNames.Main);
    }

    /// <summary>
    /// クリア時の処理
    /// </summary>
    public void gameClear()
    {
        if (isFinish) { return; }
        isFinish = true;

        SoundManager.Instance.playBGM(1);
        if (!StageSelect.unlockStage(stageNum)) {
            Invoke("goToStageSelect", 1.5f);
            return;
        }
        Invoke("goToResult", 0.75f);
    }

    /// <summary>
    /// ゲームオーバー時の処理
    /// </summary>
    public void gameOver()
    {
        if (isFinish) { return; }
        isFinish = true;

        SoundManager.Instance.playBGM(2);
        gameOverImage.SetActive(true);
        Invoke("goToStageSelect", 1.5f);
    }

    /// <summary>
    /// Invokeで使用、時間差でリザルトへ
    /// </summary>
    void goToResult()
    {
        MySceneManager.changeScene(SceneNames.Result);
    }

    /// <summary>
    /// Invokeで使用、時間差でステージセレクトへ
    /// </summary>
    void goToStageSelect()
    {
        MySceneManager.changeScene(SceneNames.StageSelect);
    }
}
