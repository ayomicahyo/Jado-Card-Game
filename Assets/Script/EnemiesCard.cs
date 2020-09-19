using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCard : MonoBehaviour
{
	public string[] enemiCardList;
	AskPanel editAsk;
	public GameObject[] cardList;
	public string enemyTakedCard;
	
    // Start is called before the first frame update
    void Start()
    {
        editAsk = GameObject.Find("EventSystem").GetComponent<AskPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
