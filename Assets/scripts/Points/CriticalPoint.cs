﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPoint : Point {
	protected override void OnClick() {
		Monster.Global.ReceiveDamage (Player.Global.DealDamage ());
		LevelController.Global.Points[gameObject] = SpawningTime;
		gameObject.SetActive(false);
	}
}
