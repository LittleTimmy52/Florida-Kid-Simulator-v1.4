using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connect : MonoBehaviourPunCallbacks
{
    public GameObject loading;
    public GameObject createOrJoin;

    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(true);
        createOrJoin.SetActive(false);

        // set the version and connect to server
        print("Connecting to server");
        PhotonNetwork.NickName = MasterManager.GameSettings.Nickname;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        loading.SetActive(false);
        createOrJoin.SetActive(true);

        print("Connected to server");
        print(PhotonNetwork.LocalPlayer.NickName);

        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconected from server, cause: " + cause.ToString());
    }
}