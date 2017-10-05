using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationManager : MonoBehaviour
{
    /// <summary>
    /// 次のページに進むボタン
    /// </summary>
    [SerializeField]
    GameObject nextButton;

    /// <summary>
    /// 前のページに戻るボタン
    /// </summary>
    [SerializeField]
    GameObject backButton;

    [SerializeField]
    GameObject operationImage;

    /// <summary>
    /// 操作説明のイメージ
    /// </summary>
    [SerializeField, Header("操作説明に使用する画像")]
    List<Sprite> operationSprites = new List<Sprite>();

    [SerializeField, Header("「戻る、次へ、タイトル」ボタン")]
    List<Sprite> buttonSprites = new List<Sprite>();

    /// <summary>
    /// 使用するイメージのインデックス
    /// </summary>
    int index = 0;

    void Start()
    {
        nextButton.GetComponent<Button>().onClick.AddListener(() => {
            ++index;
            checkPage();
        });

        backButton.GetComponent<Button>().onClick.AddListener(() => {
            --index;
            checkPage();
        });

        checkPage();
        SoundManager.Instance.playBGM(0);
    }

    /// <summary>
    /// 現在のページをチェック
    /// </summary>
    void checkPage()
    {
        if (index == 0) {
            backButton.GetComponent<Button>().interactable = false;
            nextButton.GetComponent<Button>().Select();
        }
        else if (index == 2) {
            nextButton.GetComponent<Image>().sprite = buttonSprites[2];
        }
        else if (index == 3) {
            MySceneManager.changeScene(SceneNames.Title);
            index = 2;
            return;
        }
        else {
            nextButton.GetComponent<Image>().sprite = buttonSprites[1];

            backButton.GetComponent<Image>().sprite = buttonSprites[0];
            backButton.GetComponent<Button>().interactable = true;
        }

        operationImage.GetComponent<Image>().sprite = operationSprites[index];
    }
}
