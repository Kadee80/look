using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour {
	public float minSpeed = 5.0f;
	public float maxSpeed = 5.0f;
	private float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(0f,  0f, -speed * Time.deltaTime);

	}


}
