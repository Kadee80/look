using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public Health health;


	public GUIText score;
	public static float distanceTraveled;
	public float PlayerSpeed =0.01f;
	public float minX = 0.0f, maxX = 10.0f;// we want to keep the x between 0 and 10
	public static float hits = 0.0f;
	Vector3 currentPosition;
	// Use this for initialization



	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//move formward
		//if (Time.frameCount % 5 == 0){
		transform.Translate(0f,  0f, -5f * Time.deltaTime);
			
		//}
		float MoveHorizontal = Input.GetAxis("Horizontal") ;
		transform.Translate(Vector3.right*MoveHorizontal/5);
		distanceTraveled = transform.localPosition.z;

		//move left/right


		currentPosition = transform.position;
		
		// modify the variable to keep z within minz to maxz
		currentPosition.x = 
			//limit bike to street
			Mathf.Clamp( currentPosition.x, minX, maxX);
			// and now set the transform position to our modified vector
			transform.position = currentPosition;

	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log('H');
		if(other.gameObject.tag=="car"){

			health.modifyHealth(-3);
			//Destroy(other.gameObject.GetComponent('Collider'));

			transform.Translate(Vector3.right*2);



		}
		if(other.gameObject.tag=="path"){
			hits +=1;
			score.text = "Score: " + hits;
			Destroy(other.gameObject);
		}
	}
}
