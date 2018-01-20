using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterButtons : MonoBehaviour {
	public Button DamageButton;
	public Text DamageText;
	public Button HealthButton;
	public Text HealthText;
	public Button GoldButton;
	public Text GoldText;


	void Start() {
		DamageButton.onClick.AddListener (OnDamageClick);
		HealthButton.onClick.AddListener (OnHealthClick);
		GoldButton.onClick.AddListener (OnGoldClick);

		UpdateTexts ();
	}

	void UpdateTexts() {
		DamageText.text = string.Format ("Damage - {0}%", PlayerPrefs.GetFloat ("DamageBooster", 1f) * 100);
		HealthText.text = string.Format ("Health - {0}%", PlayerPrefs.GetFloat ("HealthBooster", 1f) * 100);
		GoldText.text = string.Format ("Gold - {0}%", PlayerPrefs.GetFloat ("GoldBooster", 1f) * 100);
	}

	void OnDamageClick() {
		var gold = PlayerPrefs.GetInt ("Gold");
		if (gold >= Config.Boosters.BoosterCost) {
			PlayerPrefs.SetInt("Gold", gold - Config.Boosters.BoosterCost);
			PlayerPrefs.SetFloat("DamageBooster", PlayerPrefs.GetFloat("DamageBooster", 1) + Config.Boosters.DamageBooster);
		}
		UpdateTexts ();

	}
	void OnHealthClick() {
		var gold = PlayerPrefs.GetInt ("Gold");
		if (gold >= Config.Boosters.BoosterCost) {
			PlayerPrefs.SetInt("Gold", gold - Config.Boosters.BoosterCost);
			PlayerPrefs.SetFloat("HealthBooster", PlayerPrefs.GetFloat("HealthBooster", 1) + Config.Boosters.HealthBooster);
		}
		UpdateTexts ();

	}
	void OnGoldClick() {
		var gold = PlayerPrefs.GetInt ("Gold");
		if (gold >= Config.Boosters.BoosterCost) {
			PlayerPrefs.SetInt("Gold", gold - Config.Boosters.BoosterCost);
			PlayerPrefs.SetFloat("GoldBooster", PlayerPrefs.GetFloat("GoldBooster", 1) + Config.Boosters.GoldBooster);
		}
		UpdateTexts ();

	}
}
