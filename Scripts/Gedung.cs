using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gedung : MonoBehaviour {

    public Scrollbar healthBar;
    public float health = 300;
    public GameObject asap;
    public bool isHero;
    private Senjata senjataScript;
    public GameObject result;
    public GameObject destroy;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 50) {
            asap.SetActive(true);
            //Time.timeScale = 0;
            
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
            destroy.SetActive(true);
            NgampusArea.pauseGame = true;
            if (isHero) { NgampusArea.isMenang = false; } else { NgampusArea.isMenang = true; }
            result.SetActive(true);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        senjataScript = (Senjata)collision.gameObject.GetComponent("Senjata");
        if (isHero)
        {
            if (!senjataScript.isHero)
            {
                health = health - senjataScript.damage;
                healthBar.size = health / 100f;
                collision.gameObject.SetActive(false);
            }
        }
        else
        {
            if (senjataScript.isHero)
            {
                health = health - senjataScript.damage;
                collision.gameObject.SetActive(false);
            }
        }
    }
}
