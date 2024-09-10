using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample1 : MonoBehaviour
{
    public Transform player;      // プレイヤーの位置を取得
    public float speed = 2.0f;    // 敵の移動速度
    public float turnInterval = 1.0f; // 方向転換を行う間隔（秒）

    private Vector3 targetDirection; // プレイヤーへの方向

    void Start()
    {
        // 方向転換を1秒ごとに行うコルーチンを開始
        StartCoroutine(TurnTowardsPlayer());
    }

    void Update()
    {
        // 現在の方向に向かって敵を前進させる
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
    }

    IEnumerator TurnTowardsPlayer()
    {
        while (true)
        {
            // プレイヤーの位置と敵の位置を取得し、Y軸を無視（XZ平面のみ）
            Vector3 direction = (player.position - transform.position).normalized;

            // Y軸の方向を無視して、XZ軸のみでの方向を取得
            direction.y = 0;  // Y軸を0にすることでXZ平面でのみ追尾

            // 方向を更新
            targetDirection = direction;

            // 敵の向きをプレイヤーの方に向ける（XZ軸のみ）
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            // 次の方向転換まで1秒待つ
            yield return new WaitForSeconds(turnInterval);
        }
    }
}