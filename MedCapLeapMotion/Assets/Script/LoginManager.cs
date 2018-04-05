using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class LoginManager : MonoBehaviour {

	public GameObject go_email;
	public GameObject go_password;
	public GameObject go_login_button;
	public GameObject go_register_button;

	public Button btn_login;
	public Button btn_register;

	private string str_email;
	private string str_password;

	[Serializable]
	public class LoginDetail {
		public bool success;
		public string api_key;
		public LoginDataDetail message;
	}


	[Serializable]
	public class LoginDataDetail {
		public int id;
		public string email;
		public string name;
		public string address;
		public string tgl_lahir;
		public string phone_number;
		public string api_key;
		public int kecamatan;
		public int kota;
		public int provinsi;
		public int fisioterapis;
		public string created_at;
		public string updated_at;
		public int unit_id;
	}



	// Use this for initialization
	void Start () {
		btn_login = go_login_button.GetComponent<Button> ();
		//btn_login.onClick.AddListener (ValidateLogin);

		btn_register = go_register_button.GetComponent<Button> ();
		//btn_register.onClick.AddListener (GoToRegister);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GoToRegister(){
		SceneManager.LoadScene ("Register");
	}
   	
	public void ValidateLogin(){
		str_email = go_email.GetComponent<InputField> ().text;
		str_password = go_password.GetComponent<InputField> ().text;

		if (str_email != "" && str_password != "") {

			print (str_email);
			print (str_password);

			StartCoroutine (PostLogin(str_email,str_password));
		} else {
			print ("email or password is empty!");
		}
	}

	public IEnumerator PostLogin(string _email, string _password){
		WWWForm form = new WWWForm ();
		form.AddField ("email", _email);
		form.AddField ("password", _password);

		UnityWebRequest call_login = UnityWebRequest.Post ("http://localhost:8000/api/login", form);
		yield return call_login.Send ();

		if (call_login.error != null) {
			Debug.Log ("Error " + call_login.error);
		} else {
			Debug.Log ("Response " + call_login.downloadHandler.text);

			LoginDetail loginDetail = JsonUtility.FromJson<LoginDetail> (call_login.downloadHandler.text);
			print ("Status :" + loginDetail.success);

			ApiKey.Instance.setID (loginDetail.message.id);
			ApiKey.Instance.setApiKey (loginDetail.api_key);
		
			if (loginDetail.message.name == "") {
				SceneManager.LoadScene ("InputData");
			} else {
				SceneManager.LoadScene("Home");
			}


		}
	}


}
