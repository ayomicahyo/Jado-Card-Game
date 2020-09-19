//EAAVNwP6bxYwBADcnP7ghYocviZBZBdMf7Hm6NWwoaNFQvff3gXLa5ZCmqyGVZByCaeXEhcVZC53bCA6au26fPrCCz4BcFluOS5EIV2OTRaj1WJjrKlXCCDFoj1rsFX5iCEdB2ZADQ2SnZCvbal8JkQZC7mkoLJLi9VS1ArmtwvXbPYWMvS3KhCWFRolhhA1ZCNijP1lOoVo3XrypaLhQZAKByj5ZCPK0pqg0Y00DbeG54gzJQZDZD


using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FBManager : MonoBehaviour {
	public Text name,status;
	public GameObject btnLogin,btnNext;
	public Image photoProfile;
	
	void Awake(){
		if (!FB.IsInitialized){
			FB.Init(InitCallBack, OnHideUnity);
		}
	}
	
	private void InitCallBack(){
			
			if(FB.IsLoggedIn){
				FB.API("/me?fields=name", HttpMethod.GET, DispName);
				FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET ,GetPicture);
				btnLogin.SetActive(false);
				btnNext.SetActive(true);
			}else{
				btnLogin.SetActive(true);
				btnNext.SetActive(false);
				Debug.Log("Gagal");
			}
		
	}
	
	void OnHideUnity(bool isGameShown){
		
	}
	
	public void LogginFB(){
		var perms = new List<string>(){"public_profile", "email", "user_friends"};
		FB.LogInWithReadPermissions(perms, AuthCallBack);
	}
	
	public void LogoutFB(){
		FB.LogOut();
		
	}
	
	void AuthCallBack(ILoginResult result){
		if(!string.IsNullOrEmpty(result.Error)){
			status.text = result.ToString();
		}
	}
	
	void DispName(IResult result){
		if(!string.IsNullOrEmpty(result.Error)){
			status.text = result.ToString();
		}else{
			status.text = "SUCCESS";
			name.text = result.ResultDictionary["name"].ToString();
		}
	}
	
	void GetPicture(IGraphResult result)
         {
             if (!string.IsNullOrEmpty(result.Error))
             {
                photoProfile.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
             }
             else if(result.Error == null)
             {
                 Debug.Log("heeeeee " + result.Error);
             }
         }

}