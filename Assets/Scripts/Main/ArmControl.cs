using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour {

    private Vector3 m_Pos;
    private bool m_IsMove;
    public static bool m_IsCaught; // 掴んでいるか

    // Use this for initialization
    void Start ()
    {
        m_IsCaught = false;
        m_IsMove = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 rayPos = transform.position;
        rayPos.y -= 3.2f;
        Vector3 rayDir = new Vector3(1.0f,0.0f,0.0f);
        Debug.DrawRay(rayPos, rayDir * 0.5f);
        Ray rightRay = new Ray(rayPos, rayDir);
        rayDir = new Vector3(-1.0f, 0.0f, 0.0f);
        Ray leftRay = new Ray(rayPos, rayDir);
        Debug.DrawRay(rayPos, rayDir * 0.5f);
        RaycastHit hit;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(!Physics.Raycast(leftRay, out hit, 0.5f) && m_IsCaught)
            {
                transform.position += new Vector3(-0.05f,0f,0f); //形状位置を更新
            }
            else if(!m_IsCaught)
            {
                transform.position += new Vector3(-0.05f, 0f, 0f); //形状位置を更新
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
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

        if (Input.GetKey(KeyCode.DownArrow) && m_IsMove)
        {
            transform.position += new Vector3(0, -0.05f, 0f); //形状位置を更新
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
