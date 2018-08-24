using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    [SerializeField]
    private float _speed = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.tag == "Player"){
            // access the player
            Player player = other.GetComponent<Player>();
            if (player != null) {
                // turn triple shot bool to true
                // player.canTripleShot = true;
                player.TripleShotPowerupOn();
            }

            // destroy ourself
            Destroy(this.gameObject);

        }
    }
}
