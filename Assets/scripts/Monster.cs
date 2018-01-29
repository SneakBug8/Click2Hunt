using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour {
	public static Monster Global;
	public int MonsterIndex = 1;

	new SpriteRenderer renderer;

	int _health; 
	public int Health {
		set {
			_health = value;
			if (_health <= 0) {
				Die ();
			}
		}
		get {
			return _health;
		}
	}

	int Damage {
		get {
			return Mathf.FloorToInt(Config.Monster.baseDamage * Mathf.Pow(Config.Monster.damageProgression,MonsterIndex));
		}
	}
	public int Gold {
		get {
			return Mathf.FloorToInt(Config.Monster.baseGold * Mathf.Pow(Config.Monster.goldProgression,MonsterIndex));
		}
	}

	int maxHealth {
		get {
			return Mathf.FloorToInt(Config.Monster.baseHealth * Mathf.Pow(Config.Monster.healthProgression,MonsterIndex));
		}
	}

	float damagePause = Config.Monster.startNonAttackingTime;
	float BetweenDamage;

	public Slider HealthSlider;
	public Text NameText;

	float ShakeTime = 0f;
	readonly float ShakeOnDamage = 0.25f;
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

		ChangeSprite ();
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

		// Wait until next attack
		damagePause -= Time.deltaTime;
		if (damagePause <= 0) {
			Player.Global.ReceiveDamage (Random.Range (Damage / 2, Damage));
			damagePause = BetweenDamage;
		}
	}
	
	public void ReceiveDamage(int damage, bool sleep = true) {
		Health -= damage;
		Debug.Log (string.Format("[Monster] Changed health to {0}", Health));
		HealthSlider.value = Health;

		if (sleep) {
			ShakeTime = ShakeOnDamage;

			damagePause = BetweenDamage;
		}
	}

	public void ReceiveDamage(float damage, bool sleep = true) {
		ReceiveDamage (Mathf.FloorToInt (damage), sleep);
	}

	void Die() {
		var booster = PlayerPrefs.GetFloat("GoldBooster", 1f);
		Player.Global.ReceiveMoney(Gold * booster);

		MonsterIndex++;
		UpdateValues ();

		// Apply stun
		damagePause = Config.Monster.startNonAttackingTime;
		// Apply red anim
		RedTime = RedTimeOnDie;

		ChangeSprite ();
	}

	void ChangeSprite() {
		if (Sprites.Length == 1) {
			renderer.sprite = Sprites [0];
			return;
		}

		var lastSprite = renderer.sprite;
		var sprite = lastSprite;

		while (sprite == lastSprite) {
			sprite = Sprites [Random.Range (0, Sprites.Length)];
		}

		renderer.sprite = sprite;
	}

	void UpdateValues() {
		Health = maxHealth; // * card.Health;

		HealthSlider.maxValue = Health;
		HealthSlider.value = Health;
		NameText.text = string.Format ("Monster - {0} lvl.", MonsterIndex);

	}
}
