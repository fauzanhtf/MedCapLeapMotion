using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour {

	private GameObject go_PreviousPanel;

	public GameObject go_DataDiriPanel;
	public GameObject go_DataFisioterapis;
	public GameObject go_RiwayatPenyakit;
	public GameObject go_HistoryLatihan;
	public GameObject go_StartLatihan;

	//isi data diri panel
	public Text txt_nama;
	public Text txt_alamat;
	public Text txt_kecamatan;
	public Text txt_kabupaten;
	public Text txt_provinsi;
	public Text txt_email;
	public Text txt_phonenumber;
	public Text txt_ttl;
	public Text txt_fisioterapis;

	private ApiKey key;

	[Serializable]
	public class DataDiriDetail{
		public bool success;
		public DataDataDiriDetail message;
	}
		
	[Serializable]
	public class DataDataDiriDetail{
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
		//txt_nama = GetComponent<Text> ();
		//txt_alamat = GetComponent<Text> ();
		//txt_kecamatan = GetComponent<Text> ();
		//txt_kabupaten = GetComponent<Text> ();
		//txt_provinsi = GetComponent<Text> ();
		//txt_email = GetComponent<Text> ();
		//txt_phonenumber = GetComponent<Text> ();
		//txt_ttl = GetComponent<Text> ();
		//txt_fisioterapis = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToLatihan(){
		SceneManager.LoadScene ("Latihan");
	}

	public void OpenPanel(GameObject _gameObject){
		if (go_PreviousPanel != null) {
			go_PreviousPanel.SetActive (false);
		}

		go_PreviousPanel = _gameObject;
		go_PreviousPanel.SetActive (true);
	}

	public void ClosePanel(){
		go_PreviousPanel.SetActive (false);
	}

	public IEnumerator GetDataDiri(){
		string requestaddress = "http://localhost:8000/api/user/" + ApiKey.Instance.id + "?api_key=" + ApiKey.Instance.api_key;

		UnityWebRequest call_datadiri = UnityWebRequest.Get (requestaddress);
		yield return call_datadiri.Send ();

		Debug.Log (ApiKey.Instance.api_key);

		if (call_datadiri.error != null) {
			Debug.Log ("Error " + call_datadiri.error);
		} else {
			Debug.Log ("Response " + call_datadiri.downloadHandler.text);

			DataDiriDetail dataDiriDetail = JsonUtility.FromJson<DataDiriDetail> (call_datadiri.downloadHandler.text);

			Debug.Log (dataDiriDetail.success);
			txt_nama.text = dataDiriDetail.message.name;
			txt_alamat.text = dataDiriDetail.message.address;
			//txt_kecamatan.text = dataDiriDetail.message.kecamatan;
			//txt_kabupaten.text = dataDiriDetail.message.kota;
			//txt_provinsi.text = dataDiriDetail.message.provinsi;
			txt_email.text = dataDiriDetail.message.email;
			txt_phonenumber.text = dataDiriDetail.message.phone_number;
			//txt_ttl.text = dataDiriDetail.message.tgl_lahir;
			//txt_fisioterapis = dataDiriDetail.message.fisioterapis;

		}

	}
}
