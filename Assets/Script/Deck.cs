using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public bool deck1;
    public string[] decklist;
	public int cardInDeck;
	[SerializeField] GameObject[] card;
	
	GameManager editManager;
	
	
	void Start(){
		editManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
		StartCoroutine(wait(3f));
	}
	
	public void SuffleDeck(){
		Shuffle(decklist);
	}
	
	void Shuffle(string[] array){
		int p = editManager.jumlahKartuDeck;
		for (int n = p-1; n > 0 ; n--)
		{
			int r = Random.Range(0, n);
			string t = array[r];
			array[r] = array[n];
			array[n] = t;
		}
	}
	
	void Update(){
		if(cardInDeck == 2){
			card[0].SetActive(true);
			card[1].SetActive(true);
		} else if(cardInDeck == 1){
			card[0].SetActive(true);
			card[1].SetActive(false);
		} else if(cardInDeck == 0){
			card[0].SetActive(false);
			card[1].SetActive(false);
		} else {
			card[0].SetActive(true);
			card[1].SetActive(true);
		}
	}
	
	public void TambahKartu(){
		if(editManager.throwCard){
			cardInDeck += 1;
			decklist[cardInDeck-1] = editManager.kartuHurufDibuang;
		}
		editManager.throwCard = false;
	}
	
	public void Kurangkartu(){
		cardInDeck -= 1;
	}
	
	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		if(deck1){
			for(int i=0;i<editManager.jumlahKartuDeck;i++){
				decklist[i] = editManager.sKartuHuruf[i];
			}
			cardInDeck = editManager.jumlahKartuDeck;
		}
	}
}
