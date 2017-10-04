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
        m_Child = transform.Find("TestBlock").gameObject;
        m_Time = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!m_IsCaught)
        {
            Rigidbody rb = m_Child.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            m_Child.GetComponent<Rigidbody>().useGravity = true;
            m_Time += Time.deltaTime;
        }
        else
        {
            GameObject ClawObject = GameObject.FindGameObjectWithTag("Claw");
            //gameObject.transform.position = ClawObject.transform.position;
            m_Child.transform.position = ClawObject.transform.position;
            GetComponent<Rigidbody>().useGravity = false;
            m_Child.GetComponent<Rigidbody>().useGravity = false;
        }

        if (!ArmControl.m_CaughtEnable)
        {
            ArmControl.m_IsCaught = false;
            m_IsCaught = false;
            GetComponent<Rigidbody>().useGravity = true;
            m_Child.GetComponent<Rigidbody>().useGravity = true;
            m_Time = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Claw" &&
            m_Time > 0.5f &&
            ArmControl.m_CaughtEnable)
        {
            ArmControl.m_IsCaught = true;
            m_IsCaught = true;
            m_Child.transform.position = other.transform.position;
            ArmControl.m_CaughtTag = gameObject.tag;

            GetComponent<Rigidbody>().useGravity = false;
            m_Child.GetComponent<Rigidbody>().useGravity = false;
            Rigidbody rb = m_Child.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = m_Child.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
