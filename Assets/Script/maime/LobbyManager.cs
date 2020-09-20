using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SWNetwork;

public class LobbyManager : MonoBehaviour
{
	public enum LobbyState{
		Default,
		JoinedRoom,
	}
	
	public LobbyState State = LobbyState.Default;
	public int playercount;
	public bool debugging = false;
	public GameObject[] playerFace;
	public GameObject startUI;
	public Text status;
	public GameObject loginPanel;
	
	public string playerData;


	public Text tipeKartu;
	public string tipeTerpilih;
	public StageDB editDB;
	
    // Start is called before the first frame update
    void Start()
    {
        
		NetworkClient.Lobby.OnLobbyConnectedEvent += OnLobbyConnected;
		NetworkClient.Lobby.OnNewPlayerJoinRoomEvent += OnNewPlayerJoinRoomEvent;
		NetworkClient.Lobby.OnRoomReadyEvent += OnRoomReadyEvent;
    }
	
	void OnNewPlayerJoinRoomEvent(SWJoinRoomEventData eventData){
		if (NetworkClient.Lobby.IsOwner){
			ShowReadyToStartUI();
			GetPlayersIntheRoom();
		}
	}
	
	void OnRoomReadyEvent(SWRoomReadyEventData eventData){
		ConnectToRoom();
		
	}
	
	void Destroy(){
		NetworkClient.Lobby.OnLobbyConnectedEvent -= OnLobbyConnected;
		NetworkClient.Lobby.OnNewPlayerJoinRoomEvent -= OnNewPlayerJoinRoomEvent;
		NetworkClient.Lobby.OnRoomReadyEvent -= OnRoomReadyEvent;
	}
	
	void RegisterToLobbyServer(){
		NetworkClient.Lobby.Register(playerData, (successful, reply, error) =>{
			if (successful) {
				Debug.Log("Lobby registered " + reply);
				//GetPlayersIntheRoom();
			} else {
				Debug.Log("Lobby failed to register " + reply);
			}
		});	
	}
	
	void JoinOrCreateRoom(){
		NetworkClient.Lobby.JoinOrCreateRoom(false, 4, 0, (successful, reply, error) =>{
		if (successful){
			Debug.Log("Joined or created room " + reply);
			State = LobbyState.JoinedRoom;
			ShowJoinerRoomPopover();
			GetPlayersIntheRoom();
		}
		else{
			Debug.Log("Failed to join or create room " + error);
		}
		});
	}
	
	public void GetPlayersIntheRoom(){
		NetworkClient.Lobby.GetPlayersInRoom((successful, reply, error) =>{
			if (successful){
				Debug.Log("Got players " + reply);
				if(reply.players.Count == 1){
					playercount =1;
					playerFace[0].SetActive(true);
					playerFace[1].SetActive(false);
					playerFace[2].SetActive(false);
					playerFace[3].SetActive(false);
				}else if (reply.players.Count == 2){
					playercount =2;
					playerFace[0].SetActive(true);
					playerFace[1].SetActive(true);
					playerFace[2].SetActive(false);
					playerFace[3].SetActive(false);
				}else if (reply.players.Count == 3){
					playercount =3;
					playerFace[0].SetActive(true);
					playerFace[1].SetActive(true);
					playerFace[2].SetActive(true);
					playerFace[3].SetActive(false);
				}else if (reply.players.Count == 4){
					playercount =4;
					playerFace[0].SetActive(true);
					playerFace[1].SetActive(true);
					playerFace[2].SetActive(true);
					playerFace[3].SetActive(true);
				}else{
					
					Debug.Log("player Count : "+ playercount); // info jumlah playermasuk
					if(NetworkClient.Lobby.IsOwner){
						if(reply.players.Count == 1){
							startUI.SetActive(false);
						}else{
							ShowReadyToStartUI();
						}
					}else{
						startUI.SetActive(false);
					}
				}
			}
			else{
				Debug.Log("Failed to get players " + error);
			}
		});
	}
	
	void ShowReadyToStartUI(){
		startUI.SetActive(true);
	}
	
	void ConnectToRoom(){
		NetworkClient.Instance.ConnectToRoom((connected) =>{
			
			if (connected){
				tipeTerpilih = tipeKartu.text;
				editDB.tipeKartu = tipeTerpilih;
				//getCardToRoom();
				SceneManager.LoadScene("Gameplay");
			}else{
				Debug.Log("Failed Connect to GameServer");
			}
		});
	}
	
	void ShowJoinerRoomPopover(){
		
	}
	
	///////////////////////////////MATCH MAKING //////////////////////////////////
	public void Checkin(){
		
		NetworkClient.Instance.CheckIn(playerData, (bool successful, string error) =>
		{
			if (!successful)
			{
				Debug.LogError(error);
				status.text = "TURN ON INTERNET!";
			}else{
				loginPanel.SetActive(false);
			}
		});
		
	}
	
	//////////////////////////////// LOBBY EVENT ////////////////////////////////
	
	void OnLobbyConnected(){
		RegisterToLobbyServer();
	}
	
	
	public void CancelButton(){
		if(State == LobbyState.JoinedRoom){
			LeaveRoom();
		}
	}
	
	void LeaveRoom(){
		NetworkClient.Lobby.LeaveRoom((successful, error) =>{
			if (successful) {
				Debug.Log("Left room");
				State = LobbyState.Default;
			}
			else {
				Debug.Log("Failed to leave room " + error);
			}
		});
	}
	
	public void CreateRoom(){
	NetworkClient.Lobby.CreateRoom(playerData, true, 4, (successful, roomId, error) =>{
		if (successful) {
			Debug.Log("Room created " + roomId);
			State = LobbyState.JoinedRoom;
			GetPlayersIntheRoom();
		}
		else {
			Debug.Log("Failed to create room " + error);
		}
	});
	}
	
	public void JoinRoom(){
		NetworkClient.Lobby.JoinRoomRandomly((successful, reply, error) =>{
			if (successful) {
				Debug.Log("Joined room randomly " + reply);
				State = LobbyState.JoinedRoom;
				GetPlayersIntheRoom();
			}
			else {
				Debug.Log("Failed to Join room randomly" + error);
			}
		});
	}
	
	public void StartRoom(){
		NetworkClient.Lobby.StartRoom((successful, error) =>{
			if (successful) {
				editDB.tipeKartu = tipeKartu.text;
				Debug.Log("Started room.");
			}
			else {
				Debug.Log("Failed to start room " + error);
			}
		});
	}
	
	public void getCardToRoom(){
		if(tipeTerpilih == "Hewan"){
			for(int i=0; i<10;i++){
				editDB.sKartuObjectTerpilih[i] = editDB.kObjectHewan[i];
			}
			for(int i=0;i<26;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufHewan[i];
			}
		} else if(tipeTerpilih == "Buah"){
			for(int i=0; i<10;i++){
				editDB.sKartuObjectTerpilih[i] = editDB.kObjectBuah[i];
			}
			for(int i=0;i<26;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufBuah[i];
			}
		} else if(tipeTerpilih == "Alam"){
			for(int i=0; i<10;i++){
				editDB.sKartuObjectTerpilih[i] = editDB.kObjectAlam[i];
			}
			for(int i=0;i<26;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufAlam[i];
			}
		} else if(tipeTerpilih == "Benda"){
			for(int i=0; i<10;i++){
				editDB.sKartuObjectTerpilih[i] = editDB.kObjectBenda[i];
			}
			for(int i=0;i<26;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufBenda[i];
			}
		}
	}
}
