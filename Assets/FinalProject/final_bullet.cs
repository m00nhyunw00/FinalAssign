using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class final_bullet : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            Debug.Log("충돌한 물체의 이름: " + other.gameObject.name);
            if (other.gameObject.CompareTag("Player"))
            {
                PhotonView pv = other.gameObject.GetComponent<PhotonView>();
                if (pv != null && !pv.IsMine)
                {
                    pv.RPC("Damage", RpcTarget.AllBuffered, 0.1f);
                }
            }
            print("Heated!!");
            //Destroy(gameObject);
        }
    }
}
