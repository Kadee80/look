﻿using UnityEngine;
using System.Collections.Generic;

public class SkylineManager : MonoBehaviour {
	public Transform prefab;
	public int numberOfObjects;

	public float recycleOffset;

	public Vector3 startPosition;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	private float direction;
	
	void Start () {
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

		if (objectQueue.Peek().localPosition.z - recycleOffset > Runner.distanceTraveled) {
			Recycle();
		}

	}
	
	public Vector3 minSize, maxSize;
	
	private void Recycle () {
		Vector3 scale = new Vector3(
			Random.Range(minSize.x, maxSize.x),
			Random.Range(minSize.y, maxSize.y),
			Random.Range(minSize.z, maxSize.z));
		
		Vector3 position = nextPosition;
		position.z -= scale.z*0.5f;
		position.y += scale.y*0.5f;


		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		nextPosition.z -= scale.z;

		objectQueue.Enqueue(o);
	}
}
