using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurikiMove : MonoBehaviour
{

    Rigidbody rd;
    public float MoveSpeed = 0.5f;
    public GameObject DestroyEffect;
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
        Vector3 rayPos = transform.position;
        rayPos.y += 0.5f;
        Debug.DrawRay(rayPos, Vector3.right*0.26f);
        if(!Physics.Raycast(rayPos, Vector3.right, 0.26f))
        {
            transform.position += new Vector3(0.01f, 0f, 0f);
        }

        Vector3 ray = transform.position;
        ray.y += 0.8f;
        Vector3 rayDir = new Vector3(0, 1, 0);
        Debug.DrawRay(ray, rayDir * 2);
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
            GameManager.Instance.gameOver();
            Instantiate(DestroyEffect,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        else if (clear.gameObject.tag == "BuildingBlocks")
        {
            Vector3 rayPos = transform.position;
            rayPos.y += 1.5f;
            Vector3 rayDir = new Vector3(0,1,0);
            if (Physics.Raycast(rayPos, rayDir,0.5f))
            {
                GameManager.Instance.gameOver();
                Instantiate(DestroyEffect, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}