using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルシーンの制御クラス
/// </summary>
public class Title : MonoBehaviour
{
    [SerializeField]
    GameObject storyButton;

    [SerializeField]
    GameObject stageSelectButton;

    void Start()
    {
        SoundManager.Instance.playBGM(0);

        storyButton.GetComponent<Button>().onClick.AddListener(() => {
            SoundManager.Instance.playOverapSE(0);
            MySceneManager.changeScene(SceneNames.Story);
        });
        stageSelectButton.GetComponent<Button>().onClick.AddListener(() => {
            SoundManager.Instance.playOverapSE(0);
            MySceneManager.changeScene(SceneNames.StageSelect);
        });
    }
}
