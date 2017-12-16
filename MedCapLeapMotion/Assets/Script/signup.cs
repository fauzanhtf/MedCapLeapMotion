using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signup : MonoBehaviour {

    public InputField email_input;
    public InputField pass_input;

    Firebase.Auth.FirebaseAuth auth;

    string email, password;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void SignUp()
    {
        email = email_input.text;
        password = pass_input.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
         {
             if (task.IsCanceled)
             {
                 Debug.Log("SignUp is canceled");
                 return;
             }
             if (task.IsFaulted)
             {
                 Debug.Log("SignUp failed with error = " + task.Exception);
                 return;
             }

             Firebase.Auth.FirebaseUser user = task.Result;
             Debug.LogFormat("SignUp succesfully with = {0}({1})", user.DisplayName, user.UserId);
         });

    }
}
