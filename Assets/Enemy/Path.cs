using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

	
	public GameObject car;
	
	
	float spawnPeriod = 0.15f;
	
	private float nextSpawnTime;
	
	
	
	void Update() {
		
		transform.Translate(0f,  0f, -5f * Time.deltaTime);
		
		//how do I make the hidden game object move left/right based on perlin noise within a threshold
		
		//move left/right with perlin noise/ smooth random
		float direction = 18* Mathf.PerlinNoise(Time.time * 0.1f, 0.0F);
		//transform.Translate(Vector3.right*direction);
		Vector3 pos = transform.position;
		pos.x = direction;
		transform.position = pos;
		//Debug.Log(transform.position.x);
		
		
		if (Time.time > nextSpawnTime) { 
			

			nextSpawnTime = Time.time + spawnPeriod;
			
			GameObject clone = Instantiate(car, transform.position, transform.rotation) as GameObject;
		}


		
		
		
		
	}

}
