using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵クラス
/// </summary>
public class Enemy : MonoBehaviour
{
    float speed = 0.5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    /// <summary>
    /// 敵の死亡時に呼び出す
    /// </summary>
    void destroy()
    {
        //TODO: 死亡時の処理
    }
}
