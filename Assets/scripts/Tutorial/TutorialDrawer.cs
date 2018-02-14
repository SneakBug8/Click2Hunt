using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDrawer : MonoBehaviour {
	public string ValueName;
	public bool ShouldDestroy = true;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("Tutorial_" + ValueName) == 0) {
			PlayerPrefs.SetInt("Tutorial_" + ValueName, 1);
		}
		else {
			if (ShouldDestroy) {
				Destroy(gameObject);
			}
			else {
				gameObject.SetActive(false);
			}
		}
	}
}
