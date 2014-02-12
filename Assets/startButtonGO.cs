using UnityEngine;
using System.Collections;

public class startButtonGO : MonoBehaviour {
	public Texture2D startUp;
    public Texture2D startOver;
	public GameObject scr;

	public void Start(){
		scr = GameObject.Find("SCORE");
	}

	// Use this for initialization
    public void OnMouseEnter()
    {
        guiTexture.texture = startOver;
    }

    public void OnMouseExit()
    {
        guiTexture.texture = startUp;
    }

    public void OnMouseDown()
    {

		Destroy(scr);
        Application.LoadLevel("Level01");
    }
}

