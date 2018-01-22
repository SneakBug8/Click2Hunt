using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour {
	public static Monster Global;
	public int MonsterIndex = 1;

	SpriteRenderer renderer;

	int Health;
	int Damage;
	int Gold;

	float damagePause = Config.Monster.startNonAttackingTime;
	float BetweenDamage;

	public Slider HealthSlider;
	public Text NameText;

	float ShakeTime = 0f;
	const float ShakeOnDamage = 0.25f;
	readonly float shakeSpeed = 40f; //how fast it shakes
	readonly float shakeAmount = 0.25f; //how much it shakes

	float RedTime = 0f;
	const float RedTimeOnDie = 0.5f;

	public Sprite[] Sprites;

	// Use this for initialization
	void Awake () {
		Global = this;
	}

	void Start() {
		renderer = GetComponent<SpriteRenderer> ();

		BetweenDamage = PlayerPrefs.GetFloat ("BetweenDamage", Config.Monster.baseBetweenDamage);
		HealthSlider.minValue = 0;
		UpdateValues ();

		renderer.sprite = Sprites [Random.Range (0, Sprites.Length)];
	}

	void Update() {
		// Shake if needed
		if (ShakeTime > 0) {
			transform.position = new Vector3 (transform.position.x, Mathf.Sin (Time.time * shakeSpeed) * shakeAmount, 0);
			ShakeTime -= Time.deltaTime;
		}

		// Fade red if needed
		if (RedTime > 0) {
			var redpart = RedTime / RedTimeOnDie;
			renderer.color = Color.Lerp (Color.white, Color.red, redpart);

			RedTime -= Time.deltaTime;
		}

		// Should deal damage or not
		damagePause -= Time.deltaTime;
		if (damagePause <= 0) {
			Player.Global.ReceiveDamage (Mathf.FloorToInt (Random.Range (Damage / 2, Damage * 1.5f)));
			damagePause = BetweenDamage;
		}
	}
	
	public void ReceiveDamage(int damage) {
		Health -= damage;
		Debug.Log (string.Format("[Monster] Changed health to {0}", Health));
		HealthSlider.value = Health;
		if (Health < 0) {
			Die ();
		}

		ShakeTime = ShakeOnDamage;

		damagePause = BetweenDamage;
	}

	void Die() {
		Debug.Log ("Monster has died.");
		// TODO: Change monster sprite
		var booster = PlayerPrefs.GetFloat("GoldBooster", 1f);
		PlayerPrefs.SetFloat ("GoldBooster", 1f);
		Player.Global.ReceiveMoney(Mathf.FloorToInt(Gold * booster));
		MonsterIndex++;
		UpdateValues ();

		damagePause = Config.Monster.startNonAttackingTime;
		RedTime = RedTimeOnDie;

		renderer.sprite = Sprites [Random.Range (0, Sprites.Length)];
	}

	void UpdateValues() {
		Health = Mathf.FloorToInt(Config.Monster.baseHealth * Mathf.Pow(Config.Monster.healthProgression,MonsterIndex));
		Damage = Mathf.FloorToInt(Config.Monster.baseDamage * Mathf.Pow(Config.Monster.damageProgression,MonsterIndex));
		Gold = Mathf.FloorToInt(Config.Monster.baseGold * Mathf.Pow(Config.Monster.goldProgression,MonsterIndex));
		HealthSlider.maxValue = Health;
		HealthSlider.value = Health;
		NameText.text = string.Format ("Monster - {0} lvl.", MonsterIndex);
	}
}
