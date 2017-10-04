using UnityEngine;
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
    GameObject gameResultText;

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

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    void Start()
    {
        restartButton.SetActive(false);
        goToTitleButton.SetActive(false);
        gameResultText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
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
        SceneManager.changeScene(SceneNames.Main);
    }

    /// <summary>
    /// クリア時の処理
    /// </summary>
    public void gameClear()
    {
        gameResultText.SetActive(true);
        gameResultText.GetComponent<Text>().text = "Clear";
        StageSelect.unlockStage(stageNum);
        Invoke("goToResult", 1.0f);
    }

    /// <summary>
    /// ゲームオーバー時の処理
    /// </summary>
    public void gameOver()
    {
        gameResultText.SetActive(true);
        gameResultText.GetComponent<Text>().text = "GameOver";
        Invoke("goToStageSelect", 1.0f);
    }

    /// <summary>
    /// Invokeで使用、時間差でリザルトへ
    /// </summary>
    void goToResult()
    {
        SceneManager.changeScene(SceneNames.Result);
    }

    /// <summary>
    /// Invokeで使用、時間差でステージセレクトへ
    /// </summary>
    void goToStageSelect()
    {
        SceneManager.changeScene(SceneNames.StageSelect);
    }
}
