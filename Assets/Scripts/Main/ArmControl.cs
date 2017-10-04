using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour {

    private Vector3 m_Pos;
    private bool m_IsMove;
    public static bool m_IsCaught; // 掴んでいるか
    public static bool m_CaughtEnable;
    private bool m_IsReverse; // アニメーションを逆再生するか?

    // Use this for initialization
    void Start ()
    {
        m_IsReverse = false;
        m_CaughtEnable = false;
        m_IsCaught = false;
        m_IsMove = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 rayPos = transform.position;
        rayPos.y -= 0.6f;
        Vector3 rayDir = new Vector3(1.0f,0.0f,0.0f);
        Debug.DrawRay(rayPos, rayDir * 0.5f);
        Ray rightRay = new Ray(rayPos, rayDir);

        rayDir = new Vector3(-1.0f, 0.0f, 0.0f);
        Debug.DrawRay(rayPos, rayDir * 0.5f);
        Ray leftRay = new Ray(rayPos, rayDir);

        rayDir = new Vector3(0.0f, -1.0f, 0.0f);
        rayPos.y += 0.8f;
        rayPos.x += 0.4f;
        Debug.DrawRay(rayPos, rayDir * 0.9f);
        Ray leftDownRay = new Ray(rayPos, rayDir);

        rayPos.x = transform.position.x;
        rayPos.x -= 0.4f;
        Debug.DrawRay(rayPos, rayDir * 0.9f);
        Ray rightDownRay = new Ray(rayPos, rayDir);

        Vector3 LeftDir = new Vector3(-1.0f, 0.0f, 0.0f);
        Vector3 RightDir = new Vector3(1.0f, 0.0f, 0.0f);
        rayPos = transform.position;
        Debug.DrawRay(rayPos, LeftDir * 0.1f);
        Ray CylinderLeftRay = new Ray(rayPos, LeftDir);

        Debug.DrawRay(rayPos, RightDir * 0.1f);
        Ray CylinderRightRay = new Ray(rayPos, RightDir);

        rayPos.y += 0.5f;
        Debug.DrawRay(rayPos, RightDir * 0.23f);
        Ray CylinderUpRightRay = new Ray(rayPos, RightDir);

        rayPos.y += 0.5f;
        Debug.DrawRay(rayPos, RightDir * 0.23f);
        Ray CylinderUpLeftRay = new Ray(rayPos, LeftDir);

        RaycastHit hit;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_IsReverse = !m_IsReverse;
            if(m_IsReverse)
            {
                var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
                var animationHash = stateInfo.shortNameHash;
                GetComponent<Animator>().Play(animationHash, 0, 0);
                GetComponent<Animator>().SetFloat("Speed", 2);
            }
            else
            {
                var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
                var animationHash = stateInfo.shortNameHash;
                GetComponent<Animator>().Play(animationHash, 0, 1.4f);
                GetComponent<Animator>().SetFloat("Speed", -2);
            }
        }


        {
            var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            if(stateInfo.normalizedTime <= 1.4f && stateInfo.normalizedTime >= 0.5f)
            {
                m_CaughtEnable = true;
            }
            else if(stateInfo.normalizedTime <= 0.9f)
            {
                m_CaughtEnable = false;
            }
            else if(m_IsCaught)
            {
                m_CaughtEnable = true;
            }
            else
            {
                m_CaughtEnable = false;
            }

        }

        // 自分にめり込んでいる
        if (!Physics.Raycast(CylinderLeftRay, out hit, 0.15f) ||
            !Physics.Raycast(CylinderUpLeftRay, out hit, 0.15f))
        {
            //Debug.Log("test");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!Physics.Raycast(CylinderLeftRay, out hit, 0.15f) ||
              !Physics.Raycast(CylinderUpLeftRay, out hit, 0.15f))
            {
                if (!Physics.Raycast(leftRay, out hit, 0.5f) && m_IsCaught)
                {
                    transform.position += new Vector3(-0.05f,0f,0f); //形状位置を更新
                }
                else if(!m_IsCaught)
                {
                    transform.position += new Vector3(-0.05f, 0f, 0f); //形状位置を更新
                }
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if(!Physics.Raycast(CylinderRightRay, out hit, 0.15f) ||
              !Physics.Raycast(CylinderUpRightRay, out hit, 0.15f))
            {
                if (!Physics.Raycast(rightRay, out hit, 0.5f) && m_IsCaught)
                {
                    transform.position += new Vector3(+0.05f, 0f, 0f); //形状位置を更新
                }
                else if (!m_IsCaught)
                {
                    transform.position += new Vector3(+0.05f, 0f, 0f); //形状位置を更新
                }
            }
        }

        if(!Physics.Raycast(leftDownRay, out hit, 0.9f))
        {
            //Debug.Log("Test");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!Physics.Raycast(leftDownRay, out hit, 0.9f) &&
                !Physics.Raycast(rightDownRay, out hit, 0.9f) && 
                m_IsCaught)
            {
                transform.position += new Vector3(0, -0.05f, 0f); //形状位置を更新
            }
            else if (!m_IsCaught)
            {
                transform.position += new Vector3(0, -0.05f, 0f); //形状位置を更新
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, +0.05f, 0f); //形状位置を更新
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        m_IsMove = false;
    }

    void OnCollisionStay(Collision col)
    {
        m_IsMove = false;
    }

    void OnCollisionExit(Collision col)
    {
        m_IsMove = true;
    }
}
