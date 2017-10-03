﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リザルトシーンの制御クラス
/// </summary>
public class Result : MonoBehaviour
{
    [SerializeField]
    GameObject nextStageButton;
    
    [SerializeField]
    GameObject stageSelectButton;

    void Start()
    {
        nextStageButton.GetComponent<Button>().onClick.AddListener(() => {
            GameManager.changeStage(GameManager.StageNum + 1);
        });
        stageSelectButton.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.changeScene(SceneNames.StageSelect);
        });
    }
}
