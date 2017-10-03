using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject Buriki;
   
    // Use this for initialization
    void Start () {
        this.Buriki = GameObject.Find("Buriki");
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 BurikiPos = this.Buriki.transform.position;
        transform.position = new Vector3(BurikiPos.x,BurikiPos.y,transform.position.z);
    }
}
