//===================================================
//
//===================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZJY;
using ZJY.Framework;

public class TestSocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.A))
        {
            GameEntry.Socket.ConnectToMainSocket("192.168.1.108", 1038);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            for (int i = 0; i < 100; i++)
            {
                System_HeartbeatProto proto = new System_HeartbeatProto();
                proto.LocalTime = Time.realtimeSinceStartup * 1000;
                GameEntry.Socket.SendProtoMessage(proto);
            }
            
            //GameEntry.Socket.CloseMainSocket();
        }
    }
}
