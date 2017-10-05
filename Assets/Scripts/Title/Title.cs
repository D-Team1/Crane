using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルシーンの制御クラス
/// </summary>
public class Title : MonoBehaviour
{
    /// <summary>
    /// StorySceneに遷移するボタン
    /// </summary>
    [SerializeField]
    GameObject storyButton;

    /// <summary>
    /// StageSelectSceneに遷移するボタン
    /// </summary>
    [SerializeField]
    GameObject stageSelectButton;

    /// <summary>
    /// OperationSceneに遷移するボタン
    /// </summary>
    [SerializeField]
    GameObject operationButton;

    /// <summary>
    /// タイトル画像
    /// </summary>
    [SerializeField]
    GameObject titleImage;

    /// <summary>
    /// シーン遷移を遅らせる時間
    /// </summary>
    const float DELAY_TIME = 0.3f;

    void Start()
    {
        SoundManager.Instance.playBGM(0);

        storyButton.GetComponent<Button>().onClick.AddListener(() => {
            changeScene(SceneNames.Story);
        });
        stageSelectButton.GetComponent<Button>().onClick.AddListener(() => {
            changeScene(SceneNames.StageSelect);
        });
        operationButton.GetComponent<Button>().onClick.AddListener(() => {
            changeScene(SceneNames.Operation);
        });
    }

    void changeScene(string sceneName)
    {
        Destroy(storyButton);
        Destroy(stageSelectButton);
        Destroy(operationButton);
        Destroy(titleImage);

        if (sceneName.Equals(SceneNames.Story)) {
            Invoke("changeStory", DELAY_TIME);
        }
        else if (sceneName.Equals(SceneNames.StageSelect)) {
            Invoke("changeStageSelect", DELAY_TIME);
        }
        else {
            Invoke("changeOperation", DELAY_TIME);
        }
    }

    void changeStory()
    {
        MySceneManager.changeScene(SceneNames.Story);
    }

    void changeStageSelect()
    {
        MySceneManager.changeScene(SceneNames.StageSelect);
    }

    void changeOperation()
    {
        MySceneManager.changeScene(SceneNames.Operation);
    }
}
