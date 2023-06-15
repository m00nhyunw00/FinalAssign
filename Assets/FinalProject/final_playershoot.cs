using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class final_playershoot : MonoBehaviourPunCallbacks
{
    public GameObject Bullet;
    public Transform Gun;
    float speed = 40f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(gameObject.name + " mouse 0 down");
            if (photonView.IsMine)
            {
                print(photonView.Owner.NickName + " shoots");
                //Shoot();
                photonView.RPC("Shoot", RpcTarget.AllBuffered);
            }
            else
            {
                print(photonView.Owner.NickName + " doesn't shoot");
            }
        }
    }

    [PunRPC]    //Pun Remote Procedure Calls. Calls Remote Client's Method

    void Shoot()
    {
        Vector3 BulletPos = Gun.position + Gun.forward;
        Quaternion BulletRot = Gun.rotation;
        Vector3 BulletSpeed = Gun.forward * speed;

        GameObject Clone = Instantiate(Bullet, BulletPos, BulletRot);
        Clone.GetComponent<Rigidbody>().AddForce(BulletSpeed, ForceMode.Impulse);
        Destroy(Clone, 2f);
    }
}
