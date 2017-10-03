using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    private Vector3 m_Pos;
	// Use this for initialization
	void Start ()
    {
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

        if (Input.GetKey(KeyCode.DownArrow) &&
            gameObject.transform.position.y > 3.5f)
        {
            transform.position += new Vector3(0, -0.05f, 0f); //形状位置を更新
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, +0.05f, 0f); //形状位置を更新
        }
    }
}
