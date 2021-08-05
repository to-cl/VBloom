using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ModeController : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject VRPlayer1;
    [SerializeField] GameObject VRPlayer2;
    [SerializeField] GameObject VRPlayer3;
    [SerializeField] GameObject VRPlayer4;
    [SerializeField] GameObject VRPlayer5;
    [SerializeField] GameObject VRPlayer6;

    [SerializeField] GameObject VRAvatar;

    [SerializeField] GameObject DroneUI;
    /*   [SerializeField] GameObject InputModule;
      [SerializeField] GameObject FollowHead; */

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.NickName == "DesktopUser")
        {
            Debug.Log(PhotonNetwork.NickName);
            mainCamera.SetActive(true);

            VRPlayer1.SetActive(false);
            VRPlayer2.SetActive(false);
            VRPlayer3.SetActive(false);
            VRPlayer4.SetActive(false);
            VRPlayer5.SetActive(false);
            VRPlayer6.SetActive(false);




            /* Transform[] allChildren = VRPlayer.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                child.gameObject.SetActive(false);
                
            } */
            VRAvatar.SetActive(true);
            DroneUI.SetActive(true);

            /*   SteamVRObjects.SetActive(false);
              InputModule.SetActive(false);
              FollowHead.SetActive(false); */
        }
        if (PhotonNetwork.NickName == "VRUser")
        {
            Debug.Log(PhotonNetwork.NickName);
            mainCamera.SetActive(false);
            DroneUI.SetActive(false);
            /* Transform[] allChildren = VRPlayer.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                child.gameObject.SetActive(true);
            } */
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
