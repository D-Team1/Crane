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
    /// 戻るボタン
    /// </summary>
    [SerializeField]
    GameObject backButton;

    /// <summary>
    /// ステージセレクトボタンのスプライト
    /// </summary>
    [SerializeField, Header("ステージ選択ボタンのスプライト")]
    List<Sprite> stageButtonSprite = new List<Sprite>();
    

    /// <summary>
    /// EventSystemの参照
    /// </summary>
    GameObject es;

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
        SoundManager.Instance.playBGM(0);
        es = GameObject.Find("EventSystem")as GameObject;

        for (int i = 0; i < unlockStages.Length; ++i) {
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
                        
            obj.GetComponent<Image>().sprite = stageButtonSprite[i];
            obj.GetComponent<Button>().interactable = unlockStages[i];
        }

        backButton.GetComponent<Button>().onClick.AddListener(() => {
            MySceneManager.changeScene(SceneNames.Title);
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            for (int i = 0; i < unlockStages.Length; ++i) {
                unlockStages[i] = true;
            }

            MySceneManager.changeScene(SceneNames.StageSelect);
        }
    }

    public static void unlockStage(int stageIndex)
    {
        unlockStages[stageIndex] = true;
    }
}
