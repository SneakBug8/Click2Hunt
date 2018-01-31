using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPoint : Point {
	const float SpawningTime = 0.5f;

	protected override void OnClick() {
		Monster.Global.ReceiveDamage (Player.Global.DealDamage ());
		LevelController.Global.Points.Remove (gameObject);
		LevelController.Global.SpawnQueue.Add (SpawningTime);
		Destroy (gameObject);
	}
}
