using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiKey : MonoBehaviour {

	public static ApiKey Instance;

	public int id;
	public string api_key;

	void Awake(){
		if (Instance != null) {
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (this.gameObject);

		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setID(int _id){
		id = _id;
	}

	public void setApiKey(string _apikey){
		api_key = _apikey;
	}
}
