using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCard : MonoBehaviour
{
	public int i=0;
	public string nameObject;
	public GameObject cardView;
	GameManager editManager;
	public string[] charNeed;
	public int calculationcardNeed, cardFound;
	private bool find = false;
	
    // Start is called before the first frame update
    void Start()
    {
		editManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
		calculationcardNeed = charNeed.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SeeAObjectCard(){
		cardView.SetActive(true);
		for(int i=0; i< editManager.sKartuObject.Length;i++){
			if(nameObject == editManager.sKartuObject[i]){
				cardView.GetComponent<Image>().sprite = editManager.gkartuObject[i];
			}
		}
	}
	
	public void cekKelengkapanObject(){
		do {
			for(int j = 0;j<5;j++){
				for(int k=0;k<charNeed.Length;k++){
					if( editManager.playercardList[i].GetComponent<CardList>().cardInhand[j] == charNeed[k]){
						cardFound +=1;
					}
				}
			}
			if ( cardFound != calculationcardNeed){
				cardFound =0;
				i += 1;
			}else{
				Debug.Log("CARD FOUND ON PLAYER "+i);
				find = true;
			}
		} while( find == false && i <= 3);
		i = 0;
	}
}
