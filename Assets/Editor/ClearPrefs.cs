using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ClearPrefs : MonoBehaviour {

	[MenuItem("Tools/Delete Player Prefs")]
	static void ClearPlayerPrefs () {
		PlayerPrefs.DeleteAll ();
		Debug.Log ("Deleted player preferences");
	}
}
