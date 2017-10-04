using UnityEngine;

public class GoToTitleButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.restart();
        SceneManager.changeScene(SceneNames.Title);
    }
}
