using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notes:
/* transform is a property inherent to the current class / gameobject, so in this case of Player
 */
public class Player : MonoBehaviour {

    public bool canTripleShot = false;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f; // no serializing this b/c this keeps track of time passed

    // Serialization = make available in editor but still private
    [SerializeField]
    private float _speed = 5.0f;

	// Use this for initialization
	private void Start () {
        transform.position = new Vector3(0, 0, 0);
	}

    // Update is called once per frame
    private void Update()
    {
        Movement();

        // if space key pressed, spawn laser at player position
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
	}

    private void Shoot() {
        if (Time.time > _canFire) {
            if (canTripleShot) {
                //Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
                //strange error of not appearing on screen
                Instantiate(_laserPrefab, transform.position + new Vector3(-0.55f, 0.06f, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(0.55f, 0.06f, 0), Quaternion.identity);
            } else {
                // Quaternion.identity = no rotation pls
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    private void Movement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(_speed * horizontalInput * Time.deltaTime, _speed * verticalInput * Time.deltaTime, 0));

        // player bounds for x and y pos
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        else if (transform.position.x > 11.5f)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.5f)
        {
            transform.position = new Vector3(11.5f, transform.position.y, 0);
        }
    }

    public void TripleShotPowerupOn() {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine() {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
}
