using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SWNetwork;
//using SWNetwork.RPC;

public class GameManage : MonoBehaviour
{
    public Text status;
	
	RemoteEventAgent remoteEventAgent;

    void Start () {
        remoteEventAgent = gameObject.GetComponent<RemoteEventAgent>();
		SuffleAll();
		
	}

	void OnDestroy()
	{
		remoteEventAgent.RemoveListener("suffle", RemoteSuffle);
	}
	
	public void SuffleAll(){
		SWNetworkMessage msg = new SWNetworkMessage();
        msg.Push(status);
		remoteEventAgent.Invoke("suffle", msg);
	}
	
	public void Suffle(){
		//remoteEventAgent.AddListener("suffle", RemoteSuffle);
		if(NetworkClient.Instance.IsHost){
			status.text ="Greate!!";
		}else{
			Debug.Log("gagal");
		}
		
	}
	
	public void RemoteSuffle(SWNetworkMessage msg)
	{
		status.text ="Greate!!";
	}
	
}
