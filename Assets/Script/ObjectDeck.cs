using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDeck : MonoBehaviour
{
	public string[] decklist;
	public int cardInDeck=10;
	
	public GameObject[] objectCard;
	
	GameManager editManager;
    // Start is called before the first frame update
    void Start()
    {
		editManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
        StartCoroutine(wait(2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		for(int i=0;i<10;i++){
			decklist[i] = editManager.sKartuObject[i];
		}
		
		for(int i=0;i<4;i++){
			objectCard[i].GetComponent<Image>().sprite = editManager.gkartuObject[i];
			objectCard[i].GetComponent<ObjectCard>().nameObject = decklist[i];
		}
	}
}
