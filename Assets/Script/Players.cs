using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
	public int playerNumber;
	public string nickname;
	public float timePerTurn;
	public GameObject turnTimer;
	public bool playerTurn;
	public GameObject cardList;
	
	private GameObject turnView;
	
    // Start is called before the first frame update
    void Start()
    {
        turnView = GameObject.Find("turnShow");
    }
	
	void Update(){
		if (playerTurn == true)
        {
            //Reduce fill amount over 20 seconds
            turnTimer.GetComponent<Image>().fillAmount -= 1.0f / timePerTurn * Time.deltaTime;
        } else {
			turnTimer.SetActive(false);
		}
	}
	
	public void StartTurn(){
		playerTurn = true;
		turnTimer.GetComponent<Image>().fillAmount = 1f;
		turnTimer.SetActive(true);
		turnView.GetComponent<Text>().text = nickname+" TURN!";
		turnView.SetActive(true);
		StartCoroutine(turnViewtimer(3f));
	}
	public void EndTurn(){
		playerTurn = false;
	}
	
	IEnumerator turnViewtimer(float time){
		yield return new WaitForSeconds(time);
		turnView.SetActive(false);
	}
}
