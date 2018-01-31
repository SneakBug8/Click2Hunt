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

	[MenuItem("Tools/Add money")]
	static void AddMoney() {
		PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt ("Gold", 0) + 1000);
		Debug.Log ("Added 1000 gold");
	}

	/*[MenuItem("Tools/List Materials")]
	static void ListMaterials() {
		int j = 0;
		foreach (Material i in Selection.activeGameObject.GetComponent<Text>().material) {
			print(string.Format("[{0}] {1}", j, i.name));
			j++;
		}
	} */
}
