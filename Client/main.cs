using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class main : MonoBehaviour{
    connection _connection = null;
    void Awake(){
        GameObject _connectionObject = new GameObject();
        _connection = _connectionObject.AddComponent<connection>();
        _connection.Init();
        Invoke("SendCommand",0.1f); //等 websocket.OnOpen再送
        Invoke("Init",0.2f); //延遲執行，因為這樣資料才會更新
    }
    void Start(){
    }
    void SendCommand(){
        _connection.Send("wilson");
    }
    //程式開始
    void Init(){
        Debug.Log(playerData.name);
    }
    void OnDestroy(){
    }
}