using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ストーリーシーンの管理クラス
/// </summary>
public class StorySceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject backButton;
    
    void Start()
    {
        SoundManager.Instance.playBGM(0);
        backButton.GetComponent<Button>().onClick.AddListener(() => {
            MySceneManager.changeScene(SceneNames.Title);
        });
    }
}
