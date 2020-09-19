using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginBtn : MonoBehaviour
{
	public Text inputField,nickName;
	
	
	private LobbyManager useLobbyManager;
	
	void Start(){
			useLobbyManager = GameObject.Find("Networking").GetComponent<LobbyManager>();
	}
	
    public void OnClick(){
		if(inputField.text == ""){
			Debug.Log("INPUT NICKNAME PLEASE");
		}else{
			nickName.text = inputField.text;
			useLobbyManager.playerData = nickName.text;
			useLobbyManager.Checkin();
		}
	}
}
