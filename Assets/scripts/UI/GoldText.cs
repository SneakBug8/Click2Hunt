using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : Text {

	void Update() {
		text = "Gold - " + PlayerPrefs.GetInt ("Gold");
	}
}
