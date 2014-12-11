using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {

	// Use this for initialization
    public static int level;
	
    public void klikLevel()
    {
        Application.LoadLevel("level");
    }

    public void klikPlay(int id)
    {
        level = id;
        Application.LoadLevel("play");
    }
}
