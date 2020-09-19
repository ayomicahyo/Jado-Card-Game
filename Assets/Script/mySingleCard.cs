using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mySingleCard : MonoBehaviour
{
	public int cardNum;
	GameManager editManager;
	public string hurufkartu;
	
    // Start is called before the first frame update
    void Start()
    {
        editManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
    }

    public void SendACard(){
		if (editManager.throwCard){
			editManager.kartuHurufDibuang = hurufkartu;
			for( int i=0;i<6;i++){
				if ( editManager.players[editManager.playerTurn].GetComponent<Players>().cardList.GetComponent<CardList>().cardInhand[i] == hurufkartu ){
					for ( int j=i; j<6 ;j++){
						if ( j != 5){
							editManager.players[editManager.playerTurn].GetComponent<Players>().cardList.GetComponent<CardList>().cardInhand[j] =
							editManager.players[editManager.playerTurn].GetComponent<Players>().cardList.GetComponent<CardList>().cardInhand[j+1];
						} else {
							editManager.players[editManager.playerTurn].GetComponent<Players>().cardList.GetComponent<CardList>().cardInhand[j] = "";
						}
					}
					editManager.players[editManager.playerTurn].GetComponent<Players>().cardList.GetComponent<CardList>().sumCardInhand -= 1;
				}
			}
			GameObject.Find("myCard").GetComponent<MyCard>().CardUpdate();
			GameObject.Find("myCard").GetComponent<MyCard>().cardInhand[5].SetActive(false);
		}else{
			Debug.Log("BelumWaktunya buang kartu cuy");
		}
	}
	
	public void SetInfoCard(){
		hurufkartu = editManager.players[editManager.playerTurn].GetComponent<Players>().cardList.GetComponent<CardList>().cardInhand[cardNum];
	}
}
