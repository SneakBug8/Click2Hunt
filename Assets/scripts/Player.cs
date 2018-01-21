﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public static Player Global;

	int Health = Config.Player.baseHealth;
	int Damage = Config.Player.baseDamage;

	public Slider HealthSlider;
	public Text GoldText;

	public int startGold;

	void Awake() {
		Global = this;
	}

	void Start() {
		if (PlayerPrefs.HasKey ("HealthUpdates")) {
			Health = Mathf.FloorToInt(Config.Player.baseHealth * Mathf.Pow (Config.Updates.Health.Progression, PlayerPrefs.GetInt ("HealthUpdates")));
		}

		// Apply booster
		Health = Mathf.FloorToInt(Health * PlayerPrefs.GetFloat("HealthBooster", 1));
		PlayerPrefs.SetFloat ("HealthBooster", 1f);

		if (PlayerPrefs.HasKey ("DamageUpdates")) {
			Damage = Mathf.FloorToInt(Config.Player.baseDamage * Mathf.Pow(Config.Updates.Damage.Progression,PlayerPrefs.GetInt ("DamageUpdates")));
		}

		Damage = Mathf.FloorToInt(Damage * PlayerPrefs.GetFloat("DamageBooster", 1));
		PlayerPrefs.SetFloat ("DamageBooster", 1f);

		startGold = PlayerPrefs.GetInt ("Gold", 0);

		HealthSlider.minValue = 0;
		HealthSlider.maxValue = Health;
		HealthSlider.value = Health;

		ReceiveMoney (0);
	}

	public int DealDamage() {
		return Random.Range (Mathf.FloorToInt(Damage / 2f), Mathf.FloorToInt(Damage * 1.5f));
	}

	public void ReceiveDamage(int damage) {
		Health -= damage;
		Debug.Log (string.Format("[Player] Changed health to {0}", Health));
		if (Health < 0) {
			LevelController.Global.Lose ();
		}

		HealthSlider.value = Health;
	}

	public void ReceiveMoney(int gold) {
		var Gold = PlayerPrefs.GetInt ("Gold", 0);
		Debug.Log (string.Format("[Player] Now has {0} + {1} gold.", Gold, gold));
		PlayerPrefs.SetInt ("Gold", Gold + gold);

		GoldText.text = "Gold = " + startGold + " + " + (Gold + gold - startGold);
	}

	void OnDestroy() {
		if (Global == this) {
			Global = null;
		}
	}
}