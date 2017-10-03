using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ステージセレクト
/// </summary>
public class StageSelect : MonoBehaviour
{
    /// <summary>
    /// ステージ選択用ボタンのprefab
    /// </summary>
    [SerializeField]
    GameObject stageButton;

    /// <summary>
    /// EventSystemの参照
    /// </summary>
    GameObject es;

    /// <summary>
    /// ステージ数
    /// </summary>
    const int NUMBER_OF_STAGES = 15;

    /// <summary>
    /// ステージのアンロック
    /// </summary>
    static bool[] unlockStages = {
        true , false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false
    };

    void Start()
    {
        es = GameObject.Find("EventSystem")as GameObject;

        for (int i = 0; i < NUMBER_OF_STAGES; ++i) {
            var obj = Instantiate(stageButton)as GameObject;
            obj.transform.SetParent(transform, false);
            obj.GetComponentInChildren<Text>().text = (i + 1).ToString();
            obj.GetComponent<Button>().onClick.AddListener(() => {
                GameManager.changeStage(int.Parse(obj.GetComponentInChildren<Text>().text));
            });
            // 最初のボタンを選択状態に
            if (i == 0) {
                es.GetComponent<EventSystem>().firstSelectedGameObject = obj;
            }
                        
            obj.GetComponent<Button>().interactable = unlockStages[i];
        }
    }

    public static void unlockStage(int stageIndex)
    {
        unlockStages[stageIndex] = true;
    }
}
