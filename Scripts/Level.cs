using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public static int level;
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

    public void klikPlay(int id)
    {
        level = id;
        Application.LoadLevel("play");
    }

}
