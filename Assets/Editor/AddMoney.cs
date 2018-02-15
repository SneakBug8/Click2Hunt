using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AddMoney : MonoBehaviour {

	[MenuItem("Tools/Add money")]
	static void AddPlayerGold() {
		PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt ("Gold", 0) + 1000);
		Debug.Log ("Added 1000 gold");
	}
}
