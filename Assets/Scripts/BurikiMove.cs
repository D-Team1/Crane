﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurikiMove : MonoBehaviour
{

    Rigidbody rd;
    float MoveSpeed = 0.01f;
    public GameObject DestroyEffect;
    private Animator anim;
    RaycastHit hit;

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
        Debug.DrawRay(rayPos, Vector3.right*0.28f);
        if(!Physics.Raycast(rayPos, Vector3.right, 0.28f))
        {
            transform.position += new Vector3(MoveSpeed, 0f, 0f);
        }

        Vector3 rightUpRayPos = transform.position;
        Vector3 leftUpRayPos = transform.position;
        rightUpRayPos.y += 0.4f;
        rightUpRayPos.x += 0.2f;

        leftUpRayPos.y += 0.4f;
        leftUpRayPos.x -= 0.2f;
        Debug.DrawRay(rightUpRayPos, Vector3.up * 0.8f);
        Debug.DrawRay(leftUpRayPos, Vector3.up * 0.8f);

        //anim.SetFloat("speed");
    }

    void OnDrawGizmos()
    {
        Vector3 ray = transform.position;
        ray.y += 1.0f;
        Gizmos.DrawWireSphere(ray, 0.23f);
    }

    void OnCollisionEnter(Collision clear)
    {
        if (clear.gameObject.tag == "Goal")
        {
            MoveSpeed = 0.0f;
            anim.speed = 0.0f;
            GameManager.Instance.gameClear();
        }
        else if (clear.gameObject.tag == "GameOver")
        {
            SoundManager.Instance.playSE(3);
            GameManager.Instance.gameOver();
            Instantiate(DestroyEffect,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        else if (clear.gameObject.tag == "BuildingBlocks")
        {
            Vector3 rightUpRayPos = transform.position;
            Vector3 leftUpRayPos = transform.position;

            rightUpRayPos.y += 0.4f;
            rightUpRayPos.x += 0.2f;

            leftUpRayPos.y += 0.4f;
            leftUpRayPos.x -= 0.2f;
            Ray rightUpRay = new Ray(rightUpRayPos, Vector3.up);

            if(Physics.Raycast(rightUpRayPos, Vector3.up, out hit, 1.0f) ||
                Physics.Raycast(leftUpRayPos, Vector3.up, out hit, 1.0f))
            {
                //Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "BuildingBlocks")
                {
                    GameManager.Instance.gameOver();
                    Instantiate(DestroyEffect, gameObject.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            //if (Physics.SphereCast(ray, 0.23f, out hit, 0.4f))
            {
                //Debug.Log(hit.transform.tag);
                //if(hit.transform.tag == "BuildingBlocks")
                //{
                //    GameManager.Instance.gameOver();
                //    Instantiate(DestroyEffect, gameObject.transform.position, Quaternion.identity);
                //    Destroy(gameObject);
                //}
            }

            //if (Physics.Raycast(rayPos, rayDir,0.5f))
            //{
            //}
        }
    }
}