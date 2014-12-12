using UnityEngine;
using System.Collections;

public class menuscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void klikLevel()
    {
        Application.LoadLevel("level");
    }

    public void klikPlay()
    {
        Application.LoadLevel("play");
    }

    public void klikHelp()
    {
        Application.LoadLevel("help");
    }

    public void klikKredit()
    {
        Application.LoadLevel("about");
    }

}
