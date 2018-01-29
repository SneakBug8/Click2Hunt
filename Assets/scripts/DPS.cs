using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS : MonoBehaviour {

	public int DamagePerSecond;

	public static DPS Global;

	float BeforeDamage = 1f;

	void Awake() {
		Global = this;
	}
	
	// Update is called once per frame
	void Update () {
		BeforeDamage -= Time.deltaTime;

		if (BeforeDamage <= 0) {
			Monster.Global.ReceiveDamage (DamagePerSecond, false);
			BeforeDamage = 1f;
		}
	}
}
