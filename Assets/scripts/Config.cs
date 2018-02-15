using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config {
	public static PlayerConfig Player = new PlayerConfig ();
	public static UpdatesConfig Updates = new UpdatesConfig ();
	public static MonsterConfig Monster = new MonsterConfig ();
	public static BoostersConfig Boosters = new BoostersConfig();

	public static bool ShowAds = false;
}

public class PlayerConfig {
	public readonly int baseHealth = 100;
	public readonly int baseDamage = 10;
}

public class UpdatesConfig {
	public DamageUpdateConfig Damage = new DamageUpdateConfig ();
	public HealthUpdateConfig Health = new HealthUpdateConfig ();
	public StunUpdateConfig Stun = new StunUpdateConfig();
}

public class DamageUpdateConfig {
	public readonly float Progression = 1.5f;
	public readonly int baseCost = 25;
	public readonly float CostProgression = 2f;
}

public class HealthUpdateConfig {
	public readonly float Progression = 1.5f;
	public readonly int baseCost = 50;
	public readonly float CostProgression = 2f;

}

public class StunUpdateConfig {
	public readonly float Change = 0.05f;
	public readonly int baseCost = 200;
	public readonly float CostProgression = 2f;
}

public class BoostersConfig {
	public readonly int BoosterCost = 100;
	public readonly float DamageBooster = 0.25f;
	public readonly float HealthBooster = 0.25f;
	public readonly float GoldBooster = 0.25f;

}

public class MonsterConfig {
	public readonly int baseHealth = 50;
	public readonly int baseDamage = 5;
	public readonly int baseGold = 10;

	public readonly float healthProgression = 1.2f;
	public readonly float damageProgression = 1.2f;
	public readonly float goldProgression = 1.1f;

	public readonly float baseBetweenDamage = 0.6f;

	public readonly float startNonAttackingTime = 1f;
}