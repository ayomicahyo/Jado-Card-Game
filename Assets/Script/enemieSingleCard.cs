using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieSingleCard : MonoBehaviour
{
	public int cardNum;
	AskPanel editAsk;
	EnemiesCard editenemiesCardList;
	public string cardText;
	GameManager editManager;
	private GameObject cardList;
	MyCard editMyCard;
    // Start is called before the first frame update
    void Start()
    {
        editAsk = GameObject.Find("EventSystem").GetComponent<AskPanel>();
		editenemiesCardList = GameObject.Find("enemytchoose").GetComponent<EnemiesCard>();
		editManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
		editMyCard = GameObject.Find("myCard").GetComponent<MyCard>();
    }

    public void TakeACard(){
		cardText = editenemiesCardList.enemiCardList[cardNum];
		Debug.Log("Take a "+ cardText+" Card");
		editenemiesCardList.enemyTakedCard = cardText;
		GameObject.Find("enemytchoose").SetActive(false);
		
		cardList = editManager.players[editManager.playerTurnActive].GetComponent<Players>().cardList;//.GetComponent<CardList>().cardInhand[6] == cardText;
		cardList.GetComponent<CardList>().cardInhand[5] = cardText;
		cardList.GetComponent<CardList>().sumCardInhand += 1;
		cardList.GetComponent<CardList>().cardnum[5].SetActive(true);
		editMyCard.cardInhand[5].SetActive(true);
		editMyCard.CardUpdate();
		editManager.throwCard = true;
	}	
}
