using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class final_playermove : MonoBehaviourPunCallbacks
{
    /*void Update()
    {
        if(photonView.IsMine)
        {
            //rotate
            float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500f;
            transform.Rotate(0, h, 0);

            //move
            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime * 3f;
            transform.Translate(0, 0, v);
        }

        if(transform.position.y < -5)
        {
            Vector2 randomPos = Random.insideUnitCircle * 5f;
            transform.position = new Vector3(randomPos.x, 0, randomPos.y);
        }
    }
    */
    
}
