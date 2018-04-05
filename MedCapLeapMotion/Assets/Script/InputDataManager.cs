using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class InputDataManager : MonoBehaviour {

	public GameObject go_nama;
	public GameObject go_alamat;
	public GameObject go_kecamatan;
	public GameObject go_kota;
	public GameObject go_provinsi;
	public Text txt_email;
	public GameObject go_nomortelepon;
	public GameObject go_tanggal;
	public GameObject go_bulan;
	public GameObject go_tahun;
	public GameObject go_fisioterapis;

	public string str_nama;
	public string str_alamat;
	public int int_kecamatan;
	public int int_kota;
	public int int_provinsi;
	public string str_nomortelepon;
	public int int_tanggal;
	public int int_bulan;
	public int int_tahun;
	public int int_fisioterapis;

	[Serializable]
	public class InputDataDetail{
		public bool success;
		public DataInputDetail message;
	}

	[Serializable]
	public class DataInputDetail {
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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void SimpanData(){
	
	}

	public void ValidatorInput(){
		str_nama = go_nama.GetComponent<InputField> ().text;
		str_alamat = go_alamat.GetComponent<InputField> ().text;
		str_nomortelepon = go_nomortelepon.GetComponent<InputField> ().text;

		if (str_nama != "" && str_alamat != "" && str_nomortelepon != "") {
			StartCoroutine(InputData (str_nama, str_alamat, str_nomortelepon));
		} else {
			print ("Data tidak boleh kosong!");
		}
	}

	IEnumerator InputData(string _nama, string _alamat, string _nomortelepon){
		WWWForm form = new WWWForm ();
		form.AddField ("name", _nama);
		form.AddField ("address", _alamat);
		form.AddField ("phone_number", _nomortelepon);

		string requestaddress = "http://localhost:8000/api/update/" + ApiKey.Instance.id + "?api_key=" + ApiKey.Instance.api_key;

		UnityWebRequest call_InputData = UnityWebRequest.Post (requestaddress, form);
		yield return call_InputData.Send ();

		if (call_InputData.error != null) {
			Debug.Log (call_InputData.error);
		} else {
			Debug.Log (call_InputData.downloadHandler.text);

			InputDataDetail inputDataDetail = JsonUtility.FromJson<InputDataDetail> (call_InputData.downloadHandler.text);

			if (inputDataDetail.success) {
				SceneManager.LoadScene ("Home");
			}
		}


	}
}
