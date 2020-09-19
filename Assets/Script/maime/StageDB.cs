using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWNetwork;

[CreateAssetMenu(fileName = "DBStageChoose")]
public class StageDB : ScriptableObject
{

	public string tipeKartu;
	
	public int[] sKartuHurufTerpilih;
	public string[] sKartuObjectTerpilih;
	
	public int[] sKartuHurufHewan; // A = [0] || Z = [25] jumlah per huruf
	public int[] sKartuHurufBuah;
	public int[] sKartuHurufAlam;
	public int[] sKartuHurufBenda;
	
	public string[] kObjectHewan;
	public string[] kObjectBuah;
	public string[] kObjectAlam;
	public string[] kObjectBenda;
	
	public Sprite[] gObjectHewan;
	public Sprite[] gObjectBuah;
	public Sprite[] gObjectAlam;
	public Sprite[] gObjectBenda;
	
	public Sprite[] gKartuHuruf;
	
}
