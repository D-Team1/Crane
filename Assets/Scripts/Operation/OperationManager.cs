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
    List<Sprite> operationImages = new List<Sprite>();

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
            nextButton.GetComponentInChildren<Text>().text = "タイトル";
        }
        else if (index == 3) {
            MySceneManager.changeScene(SceneNames.Title);
            index = 2;
            return;
        }
        else {
            nextButton.GetComponentInChildren<Text>().text = "次";

            backButton.GetComponentInChildren<Text>().text = "前";
            backButton.GetComponent<Button>().interactable = true;
        }

        operationImage.GetComponent<Image>().sprite = operationImages[index];
    }
}
