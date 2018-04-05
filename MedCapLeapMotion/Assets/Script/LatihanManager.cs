using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatihanManager : MonoBehaviour {

	class Bone{
		public float X;
		public float Y;
		public float Z;
	}

	public Text txt_posx;
	public Text txt_posy;
	public Text txt_posz;

	[SerializeField] private GameObject go_thumb_bone1;
	[SerializeField] private GameObject go_thumb_bone2;
	[SerializeField] private GameObject go_thumb_bone3;
	[SerializeField] private GameObject go_index_bone1;
	[SerializeField] private GameObject go_index_bone2;
	[SerializeField] private GameObject go_index_bone3;
	[SerializeField] private GameObject go_middle_bone1;
	[SerializeField] private GameObject go_middle_bone2;
	[SerializeField] private GameObject go_middle_bone3;
	[SerializeField] private GameObject go_pinky_bone1;
	[SerializeField] private GameObject go_pinky_bone2;
	[SerializeField] private GameObject go_pinky_bone3;
	[SerializeField] private GameObject go_ring_bone1;
	[SerializeField] private GameObject go_ring_bone2;
	[SerializeField] private GameObject go_ring_bone3;
	[SerializeField] private GameObject go_palm;
	[SerializeField] private GameObject go_forearm;

	List <Bone> list_thumb_bone_1 = new List<Bone>();
	List <Bone> list_thumb_bone_2 = new List<Bone>();
	List <Bone> list_thumb_bone_3 = new List<Bone>();
	List <Bone> list_index_bone_1 = new List<Bone>();
	List <Bone> list_index_bone_2 = new List<Bone>();
	List <Bone> list_index_bone_3 = new List<Bone>();
	List <Bone> list_middle_bone_1 = new List<Bone>();
	List <Bone> list_middle_bone_2 = new List<Bone>();
	List <Bone> list_middle_bone_3 = new List<Bone>();
	List <Bone> list_pinky_bone_1 = new List<Bone>();
	List <Bone> list_pinky_bone_2 = new List<Bone>();
	List <Bone> list_pinky_bone_3 = new List<Bone>();
	List <Bone> list_ring_bone_1 = new List<Bone>();
	List <Bone> list_ring_bone_2 = new List<Bone>();
	List <Bone> list_ring_bone_3 = new List<Bone>();
	List <Bone> list_palm = new List<Bone>();
	List <Bone> list_forearm = new List<Bone>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		trackBone ();
	}

	void trackBone(){
		recordBonePosition (go_thumb_bone1, list_thumb_bone_1);
		recordBonePosition (go_thumb_bone2, list_thumb_bone_2);
		recordBonePosition (go_thumb_bone3, list_thumb_bone_3);
		recordBonePosition (go_index_bone1, list_index_bone_1);
		recordBonePosition (go_index_bone2, list_index_bone_2);
		recordBonePosition (go_index_bone3, list_index_bone_3);
		recordBonePosition (go_middle_bone1, list_middle_bone_1);
		recordBonePosition (go_middle_bone2, list_middle_bone_2);
		recordBonePosition (go_middle_bone3, list_middle_bone_3);
		recordBonePosition (go_pinky_bone1, list_pinky_bone_1);
		recordBonePosition (go_pinky_bone2, list_pinky_bone_2);
		recordBonePosition (go_pinky_bone3, list_pinky_bone_3);
		recordBonePosition (go_ring_bone1, list_ring_bone_1);
		recordBonePosition (go_ring_bone2, list_ring_bone_2);
		recordBonePosition (go_ring_bone3, list_ring_bone_3);
		recordBonePosition (go_palm, list_palm);
		recordBonePosition (go_forearm, list_forearm);
	}

	void recordBonePosition(GameObject _gameObject, List<Bone> list){
		Bone bone = new Bone ();

		bone.X = _gameObject.transform.position.x;
		bone.Y = _gameObject.transform.position.y;
		bone.Z = _gameObject.transform.position.z;

		list.Add (bone);

		txt_posx.text = _gameObject.transform.position.x.ToString();
		txt_posy.text = _gameObject.transform.position.y.ToString();
		txt_posz.text = _gameObject.transform.position.z.ToString();
	
		print ("x = " + bone.X + "  Y = " + bone.Y + "  Z = " + bone.Z);
	}
		
}
