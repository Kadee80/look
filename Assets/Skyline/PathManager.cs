using UnityEngine;

using System.Collections.Generic;

public class PathManager : MonoBehaviour {
	public Transform prefab;
	public int numberOfObjects;
	
	public float recycleOffset;
	
	public Vector3 startPosition;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	private float direction;
	
	void Start () {
		startPosition.x += 10* Mathf.PerlinNoise(Time.time * 1.0f, 0.0F);
		objectQueue = new Queue<Transform>(numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) {
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = startPosition;

		for (int i = 0; i < numberOfObjects; i++) {
			Recycle();
		}
		
	}
	
	void Update () {
		if (objectQueue.Peek().localPosition.z + recycleOffset < Runner.distanceTraveled) {
			Recycle();
		}
			 direction = 10* Mathf.PerlinNoise(Time.time * 1.0f, 0.0F);
		
	}
	
	public Vector3 minSize, maxSize;
	
	private void Recycle () {
		Vector3 scale = new Vector3(
			direction,
			Random.Range(minSize.y, maxSize.y),
			Random.Range(minSize.z, maxSize.z));
		
		Vector3 position = nextPosition;
		position.z -= scale.z*0.5f;
		position.y += scale.y*0.5f;
			position.x += scale.x*0.5f;
		
		
		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		nextPosition.z -= scale.z;
		nextPosition.x -= scale.x;
		
		
		objectQueue.Enqueue(o);
	}
}
