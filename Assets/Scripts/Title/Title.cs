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

    void Start()
    {
        SoundManager.Instance.playBGM(0);

        storyButton.GetComponent<Button>().onClick.AddListener(() => {
            MySceneManager.changeScene(SceneNames.Story);
        });
        stageSelectButton.GetComponent<Button>().onClick.AddListener(() => {
            MySceneManager.changeScene(SceneNames.StageSelect);
        });
        operationButton.GetComponent<Button>().onClick.AddListener(() => {
            MySceneManager.changeScene(SceneNames.Operation);
        });
    }
}
