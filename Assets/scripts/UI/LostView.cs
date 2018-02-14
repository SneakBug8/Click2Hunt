using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostView : MonoBehaviour {
	public Text RecordText;

	public GameObject[] DisableObjects;

	void OnEnable() {
		var textadd = "";
		if (Monster.Global.MonsterIndex > PlayerPrefs.GetInt ("RecordLevel")) {
			PlayerPrefs.SetInt ("RecordLevel", Monster.Global.MonsterIndex);
			textadd = "\n New record!";

		}
		var text = string.Format ("Your current level - {0} \n Your record - {1}",
			Monster.Global.MonsterIndex,
			PlayerPrefs.GetInt ("RecordLevel"));
		var goldtext = string.Format ("\n You have earned {0} gold", PlayerPrefs.GetInt ("Gold") - Player.Global.startGold);
		RecordText.text = text + textadd + goldtext;

		foreach(var obj in DisableObjects) {
			obj.SetActive(false);
		}
	}
}
