using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    private float _speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // move up @ 10 speed
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        // if position on y of laser is > 5.5, destroy laser
        if (transform.position.y > 5.5f) {
            Destroy(this.gameObject);
        }
	}
}
