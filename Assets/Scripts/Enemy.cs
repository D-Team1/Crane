using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵クラス
/// </summary>
public class Enemy : MonoBehaviour
{
    float speed = 0.5f;

    Ray ray;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 当たった相手がBlockなら
        if (collision.gameObject.tag == "Block") {
            // 上部に接触したか
            if (Physics.Raycast(transform.position, Vector3.up, 10)) {
                Destroy(gameObject);
            }
        }
    }
}
