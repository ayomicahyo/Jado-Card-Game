using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
	public string[] cardInhand;
	public int sumCardInhand = 5;
	public GameObject[] cardnum;
	Deck editDeck;
	public GameObject playerFace;
	private Players editPlayer;

	
	void Start(){
		editDeck = GameObject.Find("Deck").GetComponent<Deck>();
		editPlayer = playerFace.GetComponent<Players>();
		
		for(int i=0;i<cardnum.Length;i++){
			cardnum[i].SetActive(false);
		}
	}
    // Start is called before the first frame update
    public void setCard(){
		
		for(int i =0;i<cardnum.Length;i++){
			if(i<=cardInhand.Length-1){
				cardnum[i].SetActive(true);
			}else{
				cardnum[i].SetActive(false);
			}
		}
	}
	
	public void takeCardStart(){
		if(editPlayer.playerNumber == 1 ){
			for(int i=0;i<cardInhand.Length-1;i++){
				cardInhand[i] = editDeck.decklist[i];
			}
		} else if(editPlayer.playerNumber == 2 ){
			for(int i=0;i<cardInhand.Length-1;i++){
				cardInhand[i] = editDeck.decklist[i+5];
			}
		} else if(editPlayer.playerNumber == 3 ){
			for(int i=0;i<cardInhand.Length-1;i++){
				cardInhand[i] = editDeck.decklist[i+10];
			}
		} else {
			for(int i=0;i<cardInhand.Length-1;i++){
				cardInhand[i] = editDeck.decklist[i+15];
			}
		}
		mysingleCardSet();
		
	}
	
	public void mysingleCardSet(){
		for(int j = 0; j<sumCardInhand;j++){
				GameObject.Find("myCard").GetComponent<MyCard>().cardInhand[j].GetComponent<mySingleCard>().SetInfoCard();
			}
	}
}
