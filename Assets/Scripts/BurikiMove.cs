using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurikiMove : MonoBehaviour
{

    Rigidbody rd;
    public float MoveSpeed = 0.5f;

    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //velocity::速度
        //x方向へMoveSpeed分移動させる
        rd.velocity = new Vector2(MoveSpeed, rd.velocity.y);
        
    }
    void OnCollisionEnter(Collision clear)
    {
        if (clear.gameObject.tag == "Goal")
        {
            GameManager.Instance.gameClear();
        }
    }
}

   

 