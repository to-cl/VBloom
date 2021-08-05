using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI OccupancyRateText_ForFarm;
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if(PhotonNetwork.IsConnectedAndReady) {
            PhotonNetwork.JoinLobby();
        } 
        
    }

    void Update() {
        if (Input.GetKeyDown("space"))
        {
            JoinRandomRoom();
            Debug.Log("key down");
        }
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("joined the lobby");
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + Random.Range(0, 100);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;


        string[] roomPropsInLobby = { MultiPlayerConstant.MAP_TYPE_KEY };
        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() {{
            MultiPlayerConstant.MAP_TYPE_KEY, MultiPlayerConstant.Type_Value_Farm}};

        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;


        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);

    }

    public override void OnCreatedRoom()
    {
        Debug.Log("a Room is created with the name " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("the local player " + PhotonNetwork.NickName +
        " joined the room: " + PhotonNetwork.CurrentRoom.Name);

        Debug.Log("player count: " + PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiPlayerConstant.MAP_TYPE_KEY))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiPlayerConstant.MAP_TYPE_KEY, out mapType))
            {
                Debug.Log("Joined the room with the map: " + (string)mapType);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //OccupancyRateText_ForFarm.text =  PhotonNetwork.CurrentRoom.PlayerCount + " / " + 20;
        Debug.Log("one player entered the room");
        Debug.Log("player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //OccupancyRateText_ForFarm.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " + 20;
        Debug.Log("one player left the room");
        PhotonNetwork.Disconnect();
    }

    /* override private void OnPlayerDisconnected(NetworkPlayer player) {
        PhotonNetwork.LoadLevel("landing-scene");
    }
    private void OnDisconnectedFromServer(NetworkDisconnection info) {
        
    } */

    /* public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //只在最开始会调用一次，后面就不再了
        Debug.Log("DeBug room should be updated");
        if (roomList.Count == 0)
        {
            //There is no player at all
            OccupancyRateText_ForFarm.text = 0 + " / " + 20;
        } 

        if (roomList.Count == 1)
        {
            //There is no player at all
            OccupancyRateText_ForFarm.text = "A new room is created!!";
        }

        foreach(RoomInfo room in roomList) {
            Debug.Log(room.Name);
            if (room.Name.Contains("Room")) {
                OccupancyRateText_ForFarm.text = room.PlayerCount + " / " + 20;
            }
        }
    } */

     /*  public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        //只会在自己点的时候更定？队友来了确实不会更新
        OccupancyRateText_ForFarm.text = "something strange happend" + 
        PhotonNetwork.CurrentRoom.PlayerCount + " / " + 20;
        Debug.Log("room properties changed");
    } */
 
}
