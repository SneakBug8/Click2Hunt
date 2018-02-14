using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : Point {
	protected override void OnClick() {
        Player.Global.ReceiveDamage(-Random.Range(0, Monster.Global.MonsterIndex * 5));
		Player.Global.ScaleUI();
		LevelController.Global.Points[gameObject] = SpawningTime;
		gameObject.SetActive(false);
	}
}
