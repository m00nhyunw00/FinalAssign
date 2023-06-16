using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class final_bullet : MonoBehaviourPunCallbacks
{
    private bool collided = false; // 충돌 여부를 나타내는 플래그
    private Vector3 collisionPosition; // 충돌 위치 저장 변수
    private float timer = 0f; // 타이머 변수
    private float destroyDelay = 3f; // 파괴 딜레이 시간


    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            Debug.Log("충돌한 물체의 이름: " + collision.gameObject.name);
            if (collision.gameObject.CompareTag("Player"))
            {
                PhotonView pv = collision.gameObject.GetComponent<PhotonView>();
                if (pv != null && !pv.IsMine)
                {
                    pv.RPC("Damage", RpcTarget.AllBuffered, 0.1f);
                                print("Heated!!");
                    Destroy(gameObject);

                }
            }
        }

        if ((collision.gameObject.CompareTag("Object") || collision.gameObject.CompareTag("Ground")) && !collided)
        {
            collided = true; // 충돌 플래그 설정
            collisionPosition = collision.contacts[0].point; // 충돌 위치 저장
            // 충돌 시 총알의 크기 조절 (예시로 크기를 절반으로 줄임)
            transform.localScale *= 0.5f;

        }
    }

    private void Update()
    {
        if (collided)
        {
            timer += Time.deltaTime; // 타이머 증가

            if (timer >= destroyDelay)
            {
                Destroy(gameObject); // 일정 시간이 지나면 총알 파괴
            }
            else
            {
                // 충돌 위치에서 3초 동안 머무르도록 설정
                transform.position = collisionPosition;
            }
        }
        else
        {
            timer += Time.deltaTime; // 타이머 증가

            if (timer >= destroyDelay)
            {
                Destroy(gameObject); // 일정 시간이 지나면 총알 파괴
            }
        }
    }
}
