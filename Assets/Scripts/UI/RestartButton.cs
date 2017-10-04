using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.restart();
    }
}
