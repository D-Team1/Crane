using UnityEngine;

public class GoToTitleButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.restart();
        MySceneManager.changeScene(SceneNames.Title);
    }
}
