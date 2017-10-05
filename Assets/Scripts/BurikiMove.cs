using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurikiMove : MonoBehaviour
{

    Rigidbody rd;
    public float MoveSpeed = 0.5f;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        //GetComponentの処理をキャッシュしておく
        rd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public float x = 0;
    public float y = 0;
    public float z = 0;
    void FixedUpdate()
    {
        
        transform.position += new Vector3(0.01f, 0f, 0f);
       
        //anim.SetFloat("speed");
    }



    void OnCollisionEnter(Collision clear)
    {
        if (clear.gameObject.tag == "Goal")
        {
            GameManager.Instance.gameClear();
        }
        else if (clear.gameObject.tag == "GameOver")

        {
            Debug.Log("gameover");
            SoundManager.Instance.playSE(3);
            GameManager.Instance.gameOver();
        }
    }
}