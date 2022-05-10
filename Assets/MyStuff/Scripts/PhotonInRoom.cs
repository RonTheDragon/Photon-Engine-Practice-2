using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System;

public class PhotonInRoom : MonoBehaviourPunCallbacks
{
    public TMP_Text ServerName;
    public TMP_Text HowManyPlayers;
    // Start is called before the first frame update
    void Start()
    {
        ServerName.text = PhotonNetwork.CurrentRoom.Name;
        setPlayerCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        setPlayerCount();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        setPlayerCount();
    }

    void setPlayerCount()
    {
        HowManyPlayers.text = $"Currently {PhotonNetwork.CurrentRoom.PlayerCount} in Room";
    }
}
