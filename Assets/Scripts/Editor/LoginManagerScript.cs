using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ConnectServerManager))]

public class LoginManagerScript : Editor
{

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for connecting to photon server",
         MessageType.Info);


        ConnectServerManager connectServerManager = (ConnectServerManager)target;
        if (GUILayout.Button("Desktop User"))
        {
            connectServerManager.DesktopUserConnection();
        }
        if (GUILayout.Button("VR User"))
        {
            connectServerManager.VRUserConnection();
        }
    }

}
