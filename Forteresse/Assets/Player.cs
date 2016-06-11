using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;
using System;
public class Player : NetworkBehaviour
{
    public SyncListString chatHistory = new SyncListString();
    string currentMessage = "";


    public void OnGUI()
    {
        if (isLocalPlayer)
        {
            //GUILayout.BeginArea(new Rect(10, 10, 100, 100));
            GUILayout.BeginHorizontal(GUILayout.Width(250));
           // content.tranform.postion(50, 50, 50);
            currentMessage = GUILayout.TextField(currentMessage);
            if (GUILayout.Button("Send"))
            {
                if (!string.IsNullOrEmpty(currentMessage.Trim()))
                {
                    Debug.Log("command sent");
                    CmdChatMessage(currentMessage);
                    currentMessage = string.Empty;
                }
            }
            GUILayout.EndHorizontal();
        }
        foreach (string msg in chatHistory)
        {
            GUILayout.Label(msg);
        }
    }
    [Command]
    public void CmdChatMessage(string msg)
    {
        chatHistory.Add(msg);
    }
}