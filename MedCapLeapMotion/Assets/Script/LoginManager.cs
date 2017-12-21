using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour {

    public InputField IF_email,IF_password,IF_name,IF_address;
    string s_email, s_password, s_name, s_address;

    string loginurl;

    public 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loginManager()
    {
        StartCoroutine("Login");
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("email",s_email);
        form.AddField("password", s_password);
        form.AddField("name", s_name);
        form.AddField("address", s_address);

        WWW Login = new WWW(loginurl, form);
        yield return Login;

        if(Login.error != null)
        {
            Debug.Log("Cannot Login");
        }
        else
        {
            string LoginReturn = Login.text;
            if(LoginReturn == "Success")
            {
                Debug.Log("Login Success");
            }
        }
    }

    public void toLoginScene()
    {
        SceneManager.LoadScene("login");
    }
}
