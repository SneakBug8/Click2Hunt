using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ClearPrefs : MonoBehaviour {

	[MenuItem("Tools/Delete Player Prefs")]
	static void ClearPlayerPrefs () {
		PlayerPrefs.DeleteAll ();
		Debug.Log ("Deleted player preferences");
	}

	[MenuItem("Tools/Add money")]
	static void AddMoney() {
		PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt ("Gold", 0) + 1000);
		Debug.Log ("Added 1000 gold");
	}
}
