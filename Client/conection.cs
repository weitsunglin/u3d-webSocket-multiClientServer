using System;
using UnityEngine;
using NativeWebSocket;
using System.Collections;
//unity 2019.4.40f1
    public class connection: MonoBehaviour{
        WebSocket websocket;
    public void Init(){
        websocket = new WebSocket("ws://localhost:3000");
        websocket.OnOpen += () =>{
            Debug.Log("Connection open!");
        };
        websocket.OnMessage += (bytes) =>{
            // getting the message as a string
            var recv= System.Text.Encoding.UTF8.GetString(bytes);
            playerData.name = recv;
        }; 
        websocket.OnError += (e) =>{
            Debug.Log("Error! " + e);
        };
        websocket.OnClose += (e) =>{
            Debug.Log("Connection closed!");
        };
        websocket.Connect();
    }
    public void Send(string _message){
        if(websocket.State == WebSocketState.Open){
            websocket.SendText(_message);
             Debug.Log("Send ok!");
        } 
    }
    void Update(){
        #if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
        #endif
    }
    private void OnApplicationQuit(){
        websocket.Close();
    }
}