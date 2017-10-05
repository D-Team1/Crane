using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmControl : MonoBehaviour {

    private Vector3 m_Pos;
    public static bool m_IsCaught; // 掴んでいるか
    public static bool m_CaughtEnable;
    public static string m_CaughtTag;
    private bool m_IsReverse; // アニメーションを逆再生するか?
    private float m_HpValue;
    private Slider m_HpBar;
    private float timeleft;

    // Use this for initialization
    void Start ()
    {
        timeleft = 1.0f;
        m_IsReverse = false;
        m_CaughtEnable = false;
        m_IsCaught = false;
        m_HpValue = 200;
        m_HpBar = GameObject.Find("Slider").GetComponent<Slider>();
        m_HpBar.maxValue = m_HpValue;
        m_HpBar.value = m_HpBar.maxValue;
        m_CaughtTag = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(m_CaughtTag == "BuildingBlocks")
        {
            m_HpBar.value -= 10.0f / 60.0f;
        }
        else if(m_CaughtTag == "Player")
        {
            m_HpBar.value -= 25.0f / 60.0f;
        }

        if (m_HpBar.value <= 0)
        {
            GameManager.Instance.gameOver();
        }

        if (GameManager.Instance.IsDuringPose) return;
        Vector3 rayPos = transform.position;
        rayPos.y -= 0.2f;
        Vector3 rayDir = new Vector3(1.0f,0.0f,0.0f);
        Debug.DrawRay(rayPos, rayDir * 0.3f);
        Ray rightRay = new Ray(rayPos, rayDir);

        rayDir = new Vector3(-1.0f, 0.0f, 0.0f);
        Debug.DrawRay(rayPos, rayDir * 0.3f);
        Ray leftRay = new Ray(rayPos, rayDir);

        rayDir = new Vector3(0.0f, -1.0f, 0.0f);
        rayPos.y += 0.3f;
        Debug.DrawRay(rayPos, rayDir * 0.4f);
        Ray downRay = new Ray(rayPos, rayDir);

        rayPos.x = transform.position.x;
        rayPos.x -= 0.4f;
        //Debug.DrawRay(rayPos, rayDir * 0.9f);
        Ray rightDownRay = new Ray(rayPos, rayDir);

        Vector3 LeftDir = new Vector3(-1.0f, 0.0f, 0.0f);
        Vector3 RightDir = new Vector3(1.0f, 0.0f, 0.0f);
        rayPos = transform.position;
        rayPos.y += 1.2f;
        Debug.DrawRay(rayPos, LeftDir * 0.9f);
        Ray CylinderLeftRay = new Ray(rayPos, LeftDir);

        Debug.DrawRay(rayPos, RightDir * 0.9f);
        Ray CylinderRightRay = new Ray(rayPos, RightDir);

        Debug.DrawRay(rayPos, RightDir * 0.9f);
        Vector3 downDir = new Vector3(0.0f, -1.0f, 0.0f);
        Ray CylinderDownRay = new Ray(rayPos, downDir);


        RaycastHit hit;

        var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) ||
            Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.playSE(2);
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button1) ||
            Input.GetKeyUp(KeyCode.Space)) {
            SoundManager.Instance.playSE(2);
        }
        if(InputManager.moveArm())
        {
            Debug.Log(stateInfo.normalizedTime);
            //var animationHash = stateInfo.shortNameHash;
            //GetComponent<Animator>().Play(animationHash, 0, 0);
            GetComponent<Animator>().SetFloat("Speed", 1);
        }
        else
        {
            stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            //var animationHash = stateInfo.shortNameHash;
            //GetComponent<Animator>().Play(animationHash, 0, 1.4f);
            GetComponent<Animator>().SetFloat("Speed", -1);
        }

        stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime < 0)
        {
            //Debug.Log("1");
            var animationHash = stateInfo.shortNameHash;
            GetComponent<Animator>().Play(animationHash, 0, 0);
        }
        else if(stateInfo.normalizedTime > 1.4f)
        {
            //Debug.Log("2");
            var animationHash = stateInfo.shortNameHash;
            GetComponent<Animator>().Play(animationHash, 0, 1.4f);
        }

        stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if(stateInfo.normalizedTime <= 1.4f && stateInfo.normalizedTime >= 0.5f)
        {
            m_CaughtEnable = true;
        }
        else if(stateInfo.normalizedTime <= 0.9f)
        {
            m_CaughtTag = "";
            m_CaughtEnable = false;
        }
        else if(m_IsCaught)
        {
            m_CaughtEnable = true;
        }
        else
        {
            m_CaughtTag = "";
            m_CaughtEnable = false;
        }

        // 自分にめり込んでいる
        //if (!Physics.Raycast(CylinderLeftRay, out hit, 0.15f) ||
        //    !Physics.Raycast(CylinderUpLeftRay, out hit, 0.15f))
        //{
        //    //Debug.Log("test");
        //}

        if (InputManager.left())
        {
            if (!Physics.SphereCast(CylinderLeftRay, 0.4f, out hit, 0.35f))
            {
                if (!Physics.SphereCast(leftRay,  0.4f, out hit, 0.28f) && m_IsCaught)
                {
                    transform.position += new Vector3(-0.05f,0f,0f); //形状位置を更新
                }
                else if(!m_IsCaught)
                {
                    transform.position += new Vector3(-0.05f, 0f, 0f); //形状位置を更新
                }
            }
        }
        else if(InputManager.right())
        {
            if(!Physics.SphereCast(CylinderRightRay, 0.4f, out hit, 0.35f))
            {
                if (!Physics.SphereCast(rightRay, 0.4f, out hit, 0.28f) && m_IsCaught)
                {
                    transform.position += new Vector3(+0.05f, 0f, 0f); //形状位置を更新
                }
                else if (!m_IsCaught)
                {
                    transform.position += new Vector3(+0.05f, 0f, 0f); //形状位置を更新
                }
            }
        }

        if (InputManager.down())
        {
            if(!Physics.SphereCast(CylinderDownRay, 0.45f, out hit, 0.1f))
            {
                if (!Physics.SphereCast(downRay, 0.34f, out hit, 0.5f) &&
                    m_IsCaught)
                {
                    transform.position += new Vector3(0, -0.05f, 0f); //形状位置を更新
                }
                else if (!m_IsCaught)
                {
                    transform.position += new Vector3(0, -0.05f, 0f); //形状位置を更新
                }
            }
        }
        else if (InputManager.up())
        {
            transform.position += new Vector3(0, +0.05f, 0f); //形状位置を更新
        }
    }
}
