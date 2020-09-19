using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jado{
	public class Game : MonoBehaviour
	{
		public class Player{
			string playerID;
			string playerNick;
		}
		
		public string[] player;
		
		Player localPlayer,remotePlayer;
		
		public void Awake(){
			Debug.Log("Base Awake");
			localPlayer = new Player();
			remotePlayer = new Player();
		}
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}
}
