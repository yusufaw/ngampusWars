using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour {

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    public void klikLevel()
    {
        Application.LoadLevel("level");
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
