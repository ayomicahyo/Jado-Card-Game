using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AskPanel : MonoBehaviour
{
	public int numPlayerHave;
	public Text charChoose;
	GameManager editManager;
	public GameObject askFor;
	public Text[] status;
	public GameObject[] haveOrHavent;
	private GameObject takePanel;
	
	void Start(){
		editManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
		takePanel = GameObject.Find("enemytchoose");
		takePanel.SetActive(false);
		for (int i=0;i<4;i++){
			status[i].text = " NOPE ";
			haveOrHavent[i].SetActive(false);
		}
	}
	
	void Update(){
		if(editManager.playerTurnActive == editManager.playerTurn){
			askFor.SetActive(true);
		}else{
			askFor.SetActive(false);
		}
	}
	
	public void takeAcard(){
		for(int i = 0 ; i<4 ;i++){
			haveOrHavent[i].SetActive(true);
			for(int j = 0; j<6 ;j++){
				if( editManager.playercardList[i].GetComponent<CardList>().cardInhand[j] == charChoose.text){
					Debug.Log("PLAYER "+ i +" HAVE A CARD ");
					status[i].text = " I HAVE ";
					numPlayerHave = i;
				}
			}
		}
		StartCoroutine(wait(4f));
		
	}
	
	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		for (int i=0;i<4;i++){
			status[i].text = " NOPE ";
			haveOrHavent[i].SetActive(false);
		}
		for (int j=0 ; j<6 ; j++){
			takePanel.GetComponent<EnemiesCard>().enemiCardList[j] = editManager.playercardList[numPlayerHave].GetComponent<CardList>().cardInhand[j];
		}
		takePanel.SetActive(true);
		
	}
}
