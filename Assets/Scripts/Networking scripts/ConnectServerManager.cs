using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
public class ConnectServerManager : MonoBehaviourPunCallbacks
{
    string userName;

    #region Unity methods
    void Start()
    {
       /*  if (EventSystem.current.currentSelectedGameObject.name == "Desktop Button")
        {
            DesktopUserConnection();
        }

        if (EventSystem.current.currentSelectedGameObject.name == "VR Button")
        {
            VRUserConnection();
        } */
    }

    public void DesktopUserConnection()
    {
        userName = "DesktopUser";
        PhotonNetwork.NickName = userName;
        PhotonNetwork.ConnectUsingSettings();
    }
    public void VRUserConnection()
    {
        userName = "VRUser";
        PhotonNetwork.NickName = userName;
        PhotonNetwork.ConnectUsingSettings();
    }
    #endregion

    #region Photon Callback methods
    public override void OnConnected()
    {
        Debug.Log("The server is available");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the master server with the nickname " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("farm-scene");
    }
    #endregion 
}