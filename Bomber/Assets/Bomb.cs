﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1.5f, 1.5f) , 10), ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), FindObjectOfType<Player>().GetComponent<BoxCollider2D>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
