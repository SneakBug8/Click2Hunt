﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunUpdate : MonoBehaviour {
	public Text LevelText;
	public Button UpdateButton;
	Text UpdateButtonText;

	int Cost;

	// Use this for initialization
	void Start () {
		UpdateButton.onClick.AddListener (OnClick);
		UpdateButtonText = UpdateButton.GetComponentInChildren<Text> ();
		UpdateValues ();
	}

	void UpdateValues() {
		var updatescount = PlayerPrefs.GetInt ("StunUpdates");
		Cost = Mathf.FloorToInt(Config.Updates.Stun.baseCost * Mathf.Pow(Config.Updates.Stun.CostProgression, updatescount * 1f));

		LevelText.text = string.Format("Stun {0} lvl.", updatescount);
		UpdateButtonText.text = string.Format ("Upgrade - {0} gold.", Cost);
	}

	void OnClick() {
		if (PlayerPrefs.GetInt ("Gold") >= Cost) {
			PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt ("Gold") - Cost);
			PlayerPrefs.SetInt ("StunUpdates", PlayerPrefs.GetInt ("StunUpdates") + 1);
			UpdateValues ();
		}
	}
}
