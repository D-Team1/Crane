using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour {

    private bool m_IsCaught; // 掴まれているか
    private float m_Time;
    private GameObject m_Child;

	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,0,0);
        m_IsCaught = false;
        m_Child = transform.FindChild("Cube").gameObject;
        m_Time = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(m_IsCaught)
        {
            GameObject ClawObject = GameObject.FindGameObjectWithTag("Claw");
            gameObject.transform.position = ClawObject.transform.position;
        }

        if (!m_IsCaught)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            GetComponent<Rigidbody>().useGravity = true;
            m_Child.GetComponent<Rigidbody>().useGravity = true;
            m_Time += Time.deltaTime;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
            m_Child.GetComponent<Rigidbody>().useGravity = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ArmControl.m_IsCaught = false;
            m_IsCaught = false;
            m_Time = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Claw" &&
            m_Time > 0.5f)
        {
            ArmControl.m_IsCaught = true;
            m_IsCaught = true;
            gameObject.transform.position = other.transform.position;

            GetComponent<Rigidbody>().useGravity = false;
            m_Child.GetComponent<Rigidbody>().useGravity = false;
        }
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Test");
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
