using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class RegisterManager : MonoBehaviour {

	public GameObject go_email;
	public GameObject go_password;
	public GameObject go_register_button;
	public GameObject go_back_button;

	public Button btn_register;
	public Button btn_back;

	private string str_email;
	private string str_password;

	[Serializable]
	public class RegisterDetail
	{
		public bool success;
		public string message;
	}

	// Use this for initialization
	void Start () {
		btn_register = go_register_button.GetComponent<Button> ();
		btn_back = go_back_button.GetComponent<Button> ();
		//btn_back.onClick.AddListener (GoToLogin);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToLogin() {
        SceneManager.LoadScene("Login");
    }

	public void ValidateRegister(){
		str_email = go_email.GetComponent<InputField> ().text;
		str_password = go_password.GetComponent<InputField> ().text;

		if (str_email != "" && str_password != "") {
			print (str_email);
			print (str_password);
			StartCoroutine (PostRegister (str_email, str_password));
		} else {
			print ("email or password can't be ampty !");
		}
	}

	IEnumerator PostRegister(string _email, string _password){
		WWWForm form = new WWWForm ();
		form.AddField ("email", _email);
		form.AddField ("password", _password);

		UnityWebRequest call_register = UnityWebRequest.Post("http://localhost:8000/api/register", form);
		yield return call_register.Send ();

		if (call_register.error != null) {
			Debug.Log ("Error : " + call_register.error);
		} else {
			Debug.Log ("Response : " + call_register.downloadHandler.text);

			RegisterDetail registerDetail = JsonUtility.FromJson<RegisterDetail> (call_register.downloadHandler.text);
			print (registerDetail.success);
			if (registerDetail.success) {
				SceneManager.LoadScene ("Login");
			}
		}
	}
}
