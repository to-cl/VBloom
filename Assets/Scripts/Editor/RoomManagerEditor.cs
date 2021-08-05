using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is for joining the room",
         MessageType.Info);

        RoomManager roomManager = (RoomManager)target;
        if (GUILayout.Button("Join The Room"))
        {
            roomManager.JoinRandomRoom();
        }
    }
}
