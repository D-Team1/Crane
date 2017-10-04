using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool right()
    {
        if (Input.GetAxis("Horizontal") > 0.0f) {
            return true;
        }

        return false;
    }

    public static bool left()
    {
        if (Input.GetAxis("Horizontal") < 0.0f) {
            return true;
        }

        return false;
    }

    public static bool up()
    {
        if (Input.GetAxis("Vertical") > 0.0f) {
            return true;
        }

        return false;
    }

    public static bool down()
    {
        if (Input.GetAxis("Vertical") < 0.0f) {
            return true;
        }

        return false;
    }

    // 決定
    public static bool submit()
    {
        return Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Return);
    }
    // アームの動作用
    public static bool moveArm()
    {
        return Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Return);
    }
    // ポーズ
    public static bool pose()
    {
        return Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.P); 
    }
}
