using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {


    public Player parent;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1.5f, 1.5f) , 10), ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), parent.GetComponent<BoxCollider2D>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Animator>().enabled = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        Destroy(gameObject, 1.5f);

    }
}
