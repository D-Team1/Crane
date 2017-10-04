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
        backButton.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.changeScene(SceneNames.Title);
        });
    }

    void Update()
    {

    }
}
