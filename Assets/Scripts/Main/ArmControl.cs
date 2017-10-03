using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour {

    private Vector3 m_Pos;
    private bool m_IsMove;

    // Use this for initialization
    void Start ()
    {
        m_IsMove = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.05f,0f,0f); //形状位置を更新
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(+0.05f, 0f, 0f); //形状位置を更新
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
        rb.isKinematic = true;
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
