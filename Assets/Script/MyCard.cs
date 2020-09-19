using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCard : MonoBehaviour
{
	public GameObject[] cardInhand;
	private CardList editCardlist;
	private GameManager editManager;
	bool cek = false;
	
	public GameObject card;
	
    // Start is called before the first frame update
    void Start()
    {
        editCardlist = card.GetComponent<CardList>();
		editManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
    }

	public void cekCard(){
		if(cek == true){
			transform.localPosition = new Vector2 (0,transform.localPosition.y - 100);
			cek = false;
		}else{
			transform.localPosition = new Vector2 (0,transform.localPosition.y + 100);
			cek = true;
		}
	}
	
    // Update is called once per frame
    public void CardUpdate(){
		for(int i=0;i<6;i++){
			if(editCardlist.cardInhand[i] == "A"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[0];
			}else if(editCardlist.cardInhand[i] == "B"){
				cardInhand[i].GetComponent<Image>().sprite  = editManager.kartuHuruf[1];
			}else if(editCardlist.cardInhand[i] == "C"){
				cardInhand[i].GetComponent<Image>().sprite  = editManager.kartuHuruf[2];
			}else if(editCardlist.cardInhand[i] == "D"){
				cardInhand[i].GetComponent<Image>().sprite  = editManager.kartuHuruf[3];
			}else if(editCardlist.cardInhand[i] == "E"){
				cardInhand[i].GetComponent<Image>().sprite  = editManager.kartuHuruf[4];
			}else if(editCardlist.cardInhand[i] == "F"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[5];
			}else if(editCardlist.cardInhand[i] == "G"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[6];
			}else if(editCardlist.cardInhand[i] == "H"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[7];
			}else if(editCardlist.cardInhand[i] == "I"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[8];
			}else if(editCardlist.cardInhand[i] == "J"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[9];
			}else if(editCardlist.cardInhand[i] == "K"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[10];
			}else if(editCardlist.cardInhand[i] == "L"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[11];
			}else if(editCardlist.cardInhand[i] == "M"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[12];
			}else if(editCardlist.cardInhand[i] == "N"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[13];
			}else if(editCardlist.cardInhand[i] == "O"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[14];
			}else if(editCardlist.cardInhand[i] == "P"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[15];
			}else if(editCardlist.cardInhand[i] == "Q"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[16];
			}else if(editCardlist.cardInhand[i] == "R"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[17];
			}else if(editCardlist.cardInhand[i] == "S"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[18];
			}else if(editCardlist.cardInhand[i] == "T"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[19];
			}else if(editCardlist.cardInhand[i] == "U"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[20];
			}else if(editCardlist.cardInhand[i] == "V"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[21];
			}else if(editCardlist.cardInhand[i] == "W"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[22];
			}else if(editCardlist.cardInhand[i] == "X"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[23];
			}else if(editCardlist.cardInhand[i] == "Y"){
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[24];
			}else{
				cardInhand[i].GetComponent<Image>().sprite = editManager.kartuHuruf[25];
			}
				
				
		}
	}
}
