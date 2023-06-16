using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class final_networkmanager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Screen.SetResolution(800, 600, false);  //fullscrenn = false

        string PlayerName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.NickName = PlayerName;
        print("Player Nickname : " + PhotonNetwork.NickName);


        //start connecting...
        print("Starting Connect Process...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to Master Server");
        RoomOptions ro = new RoomOptions()
        {
            MaxPlayers = 8
        };

        PhotonNetwork.JoinOrCreateRoom("Room", ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        float randomFloor = 0.0f;

        print(PhotonNetwork.NickName + " has joined the Room");

        int randomValue = Random.Range(0, 2);

        if(randomValue == 0)
        {
            randomFloor = 0.0f;
        }
        else
        {
            randomFloor = 14.0f;
        }

        //instantiate player prefab
        Vector2 randomPos = Random.insideUnitCircle * 45f;
        PhotonNetwork.Instantiate("FPSController", new Vector3(randomPos.x, randomFloor, randomPos.y), Quaternion.identity);
    }
}
