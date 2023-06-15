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
        print(PhotonNetwork.NickName + " has joined the Room");

        //instantiate player prefab
        Vector2 randomPos = Random.insideUnitCircle * 5f;
        PhotonNetwork.Instantiate("FPSController", new Vector3(randomPos.x, 0, randomPos.y), Quaternion.identity);
    }
}
