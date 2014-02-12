using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {
	public Texture2D startUp;
    public Texture2D startOver;

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

        Application.LoadLevel("Level01");
    }
}

