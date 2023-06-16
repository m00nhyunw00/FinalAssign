using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class final_playershoot : MonoBehaviourPunCallbacks
{
    public GameObject Bullet;
    public Transform Gun;
    float speed = 40f;

    private int currentAmmo = 20; // 현재 탄약 수
    private bool isReloading = false; // 재장전 중인지 여부

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(gameObject.name + " mouse 0 down");
            if (!isReloading && currentAmmo > 0)
            {
                if (photonView.IsMine)
                {
                    print(photonView.Owner.NickName + " shoots");
                    photonView.RPC("Shoot", RpcTarget.AllBuffered);
                }
                else
                {
                    print(photonView.Owner.NickName + " doesn't shoot");
                }

                currentAmmo--; // 총알 수 감소

                if (currentAmmo == 0)
                {
                    StartCoroutine(Reload()); // 장전 시작
                }
            }
        }
    }

    [PunRPC]
    void Shoot()
    {
        Vector3 BulletPos = Gun.position + Gun.forward;
        Quaternion BulletRot = Gun.rotation;
        Vector3 BulletSpeed = Gun.forward * speed;

        GameObject Clone = Instantiate(Bullet, BulletPos, BulletRot);
        Clone.GetComponent<Rigidbody>().AddForce(BulletSpeed, ForceMode.Impulse);
        //Destroy(Clone, 2f);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        print("Reloading...");

        yield return new WaitForSeconds(5f); // 5초 동안 재장전

        currentAmmo = 20; // 탄약 수를 다시 채움
        isReloading = false;
        print("Reloaded! Current Ammo: " + currentAmmo);
    }
}