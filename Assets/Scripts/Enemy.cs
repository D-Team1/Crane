using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵クラス
/// </summary>
public class Enemy : MonoBehaviour
{
    float speed = 0.5f;
    RaycastHit hit;
    
    void Update()
    {
        Vector3 rayPos = transform.position;
        rayPos.y += 0.3f;
        Debug.DrawRay(rayPos, Vector3.left * 0.4f);
        if (!Physics.Raycast(rayPos, Vector3.left, 0.4f))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        Debug.DrawRay(transform.position, Vector3.up * 3.5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 当たった相手がBlockなら
        if (collision.gameObject.tag == "BuildingBlocks") {
            // 上部に接触したか
            Vector3 rayPos = transform.position;
            rayPos.y += 0.5f;
            Ray ray = new Ray(rayPos,Vector3.up);

            if(Physics.SphereCast(ray, 0.4f, out hit, 0.8f))
            {
                Destroy(gameObject);
            }
            if (Physics.Raycast(transform.position, Vector3.up, 0.8f)) {
            }
        }
    }
}
