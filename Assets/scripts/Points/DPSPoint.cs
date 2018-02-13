using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSPoint : Point {
	protected override void OnClick() {
		DPS.Global.DamagePerSecond += Monster.Global.MonsterIndex;
		LevelController.Global.Points[gameObject] = SpawningTime;
		gameObject.SetActive(false);
	}
}
