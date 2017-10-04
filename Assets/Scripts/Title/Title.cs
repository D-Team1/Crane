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
        storyButton.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.changeScene(SceneNames.Story);
        });
        stageSelectButton.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.changeScene(SceneNames.StageSelect);
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.changeScene(SceneNames.StageSelect);
        }
    }
}
