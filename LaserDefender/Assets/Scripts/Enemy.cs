﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject player;
	public GameObject projectile;

	float firingRate = 0.5f;
	float repeatRate = 0.0000001f;

	int scorePoints = 150;
	float health = 150f;

	public float Health {
		get {
			return health;
		}
		set {
			health = value;
		}
	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		ScoreKeeper scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

	}
	
	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * firingRate;
		if (player != null && Random.value < probability) { //&& Mathf.Abs(this.transform.position.x - player.transform.position.x) <= 1f) {
			InvokeRepeating("Fire", repeatRate, firingRate);
		} else {
			CancelInvoke("Fire");
		}
	}

	void Fire() {
		GameObject shotFired = Instantiate(projectile, new Vector3(this.transform.position.x, this.transform.position.y - 1f), Quaternion.identity) as GameObject;
		shotFired.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10f);
	}
}
