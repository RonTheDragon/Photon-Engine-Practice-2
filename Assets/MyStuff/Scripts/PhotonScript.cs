using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonScript : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    bool isConnecting;

    string RoomName;

    public TMP_Text ServerList;

    public List<RoomInfo> TheRoomList;
    public GameObject Canvas;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Canvas.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Connect()
    {
        isConnecting = PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
    }
    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            Debug.Log("Connected To Photon");
            //PhotonNetwork.JoinRandomOrCreateRoom();
            isConnecting = false;
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        Canvas.SetActive(true);
    }

    public void EditName(string N)
    {
        RoomName = N;
    }

    public void MYJoin()
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public void MYCreate()
    {
        if (RoomName != string.Empty)
        PhotonNetwork.CreateRoom(RoomName);

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("bla");
        ServerList.text = string.Empty;
        foreach (RoomInfo a in roomList)
        {
            ServerList.text += $"-{a.Name}-";
        }
    }

    

    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created");
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel(1);
    }

    public void MYRefresh()
    {
        PhotonNetwork.LeaveLobby();
    }
    public override void OnLeftLobby()
    {
        PhotonNetwork.JoinLobby();
    }


}
