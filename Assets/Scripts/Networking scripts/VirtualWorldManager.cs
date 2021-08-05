using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VirtualWorldManager : MonoBehaviour
{
    public static VirtualWorldManager Instance;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }
    public void LeaveRoomAndLoadHomeScene() {
        PhotonNetwork.LeaveRoom();
        Debug.Log("virtual world manager one player leaves the room");
    }

}
