using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      
            if (Input.GetKeyUp(KeyCode.Escape))
            {

                //quit application on return button

                Application.LoadLevel("main");
            }

        
	}

    public void klikMenu()
    {
        Application.LoadLevel("main");
    }
}
