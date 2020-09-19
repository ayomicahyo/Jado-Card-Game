using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public string typekartu;
	
	public bool throwCard = false;
	public int playerTurn;
	
	public string[] sKartuHuruf;
	public int jumlahKartuDeck=0;
	public string[] sKartuObject;
	
	public GameObject[] players;
	public int playerTurnActive;
	public GameObject[] playercardList;
	private GameObject turnView;
	public Sprite[] kartuHuruf;
	
	public StageDB editDB;
	public Sprite[] gkartuObject;
	
	public GameObject[] objKartuObject;
	
	public GameObject block,ask;
	
	public string kartuHurufDibuang;
	
	int k = 0;
		int temp = 0;
		string indCard = "A";
	
    // Start is called before the first frame update
	void Awake(){
		
		
	}
	
	
    void Start()
    {
        turnView = GameObject.Find("turnShow");
		StartCoroutine(wait(1f));
		
		
		/*for(int i=0;i<10;i++){
			sKartuObject[i] = editDB.sKartuObjectTerpilih[i];
		}*/
		
		
		
		
		
		
		
		
		
    }

    public void NextTurn(){
		if(playerTurnActive != 4){
			playerTurnActive += 1;
		}else{
			playerTurnActive = 0;
		}

		for(int i=0;i<players.Length;i++){
			if(i == playerTurnActive){
				players[i].GetComponent<Players>().StartTurn();
			}else{
				players[i].GetComponent<Players>().EndTurn();
			}
		}
		cekObject();
	}
	
	public void StartGame(){
		block.SetActive(false);
		ask.SetActive(false);
		for(int i=0;i<playercardList.Length;i++){
			playercardList[i].GetComponent<CardList>().setCard();
			//NextTurn();
			
		}
	}
	
	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		turnView.SetActive(false);
		
		
		
		typekartu = editDB.tipeKartu;
		
		if(typekartu == "Benda"){
			for(int i=0;i<editDB.kObjectBenda.Length;i++){
				sKartuObject[i] = editDB.kObjectBenda[i];
			}
			for(int i=0;i<50;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufBenda[i];
			}
			for(int i=0;i<10;i++){
				gkartuObject[i] =editDB.gObjectBenda[i];
			}
		}else if(typekartu == "Hewan"){
			for(int i=0;i<editDB.kObjectHewan.Length;i++){
				sKartuObject[i] = editDB.kObjectHewan[i];
			}
			for(int i=0;i<26;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufHewan[i];
			}
			for(int i=0;i<10;i++){
				gkartuObject[i] =editDB.gObjectHewan[i];
			}
		}else if(typekartu == "Alam"){
			for(int i=0;i<editDB.kObjectAlam.Length;i++){
				sKartuObject[i] = editDB.kObjectAlam[i];
			}
			for(int i=0;i<50;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufAlam[i];
			}
			for(int i=0;i<10;i++){
				gkartuObject[i] =editDB.gObjectAlam[i];
			}
		}else if(typekartu == "Buah"){
			for(int i=0;i<editDB.kObjectBuah.Length;i++){
				sKartuObject[i] = editDB.kObjectBuah[i];
			}
			for(int i=0;i<50;i++){
				editDB.sKartuHurufTerpilih[i] = editDB.sKartuHurufBuah[i];
			}
			for(int i=0;i<10;i++){
				gkartuObject[i] =editDB.gObjectBuah[i];
			}
		}
		
		for (int i=0;i<26;i++){
			jumlahKartuDeck += editDB.sKartuHurufTerpilih[i];
		}
		
		do{
			if(k == 0){
				indCard = "A";
			}else if(k == 1){
				indCard = "B";
			}else if(k == 2){
				indCard = "C";
			}else if(k == 3){
				indCard = "D";
			}else if(k == 4){
				indCard = "E";
			}else if(k == 5){
				indCard = "F";
			}else if(k == 6){
				indCard = "G";
			}else if(k == 7){
				indCard = "H";
			}else if(k == 8){
				indCard = "I";
			}else if(k == 9){
				indCard = "J";
			}else if(k == 10){
				indCard = "K";
			}else if(k == 11){
				indCard = "L";
			}else if(k == 12){
				indCard = "M";
			}else if(k == 13){
				indCard = "N";
			}else if(k == 14){
				indCard = "O";
			}else if(k == 15){
				indCard = "P";
			}else if(k == 16){
				indCard = "Q";
			}else if(k == 17){
				indCard = "R";
			}else if(k == 18){
				indCard = "S";
			}else if(k == 19){
				indCard = "T";
			}else if(k == 20){
				indCard = "U";
			}else if(k == 21){
				indCard = "V";
			}else if(k == 22){
				indCard = "W";
			}else if(k == 23){
				indCard = "X";
			}else if(k == 24){
				indCard = "Y";
			}else{
				indCard = "Z";
			}
			
			for(int j=0;j<editDB.sKartuHurufTerpilih[k];j++){
				sKartuHuruf[temp] = indCard;
				temp++;
			}
			k++;
		}while(temp != jumlahKartuDeck);
	}
	
	public void ThrowAPlayerCard(){
		throwCard = true;
	}
	
	public void cekObject(){
		Debug.Log("cekObject");
		for(int i=0; i < objKartuObject.Length;i++){
			objKartuObject[i].GetComponent<ObjectCard>().cekKelengkapanObject();
		}
	}
}
