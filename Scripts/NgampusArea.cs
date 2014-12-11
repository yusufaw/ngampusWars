using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NgampusArea : MonoBehaviour
{
    public GameObject hero1, hero2, hero3, hero4, pauseImage;
    public GameObject enemy1, enemy2, enemy3, enemy4;
    private bool pauseGame = false, enemyShowed = true, hero1Showed = true, hero2Showed = true, hero3Showed = true, hero4Showed = true;
    private Vector2 startPos;
    public float minSwipeDistY, minSwipeDistX, loadTimeHero1 = 2, loadTimeHero2 = 2, loadTimeHero3 = 2, loadTimeHero4 = 2;
    public Text textTime, textMana;
    public Button button1, button2, button3, button4;
    public float timer = 0, manaHero = 0, manaEnemy = 0, manaLevelHero = 1, manaLevelEnemy = 1;
    public float showSpeed = 4;
    public float minManaHero1 = 10, minManaHero2 = 30, minManaHero3 = 80, minManaHero4 = 100;
    public float minManaEnemy1 = 10, minManaEnemy2 = 30, minManaEnemy3 = 80, minManaEnemy4 = 100;

    void Start()
    {
        //StartCoroutine(showEnemy());
        button1.enabled = button2.enabled = button3.enabled = button4.enabled = false;
        //button1 = (Button)GameObject.Find("button hero 1");
    }

    void Update()
    {
        if (Scene.level == 1)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (enemyShowed) StartCoroutine(showEnemy());
        }
        else if (Scene.level == 2)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
        }
        else if (Scene.level == 3)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
            if (hero3Showed && manaHero >= minManaHero3) { button3.enabled = true; } else { button3.enabled = false; }
        }
        else if (Scene.level == 4)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
            if (hero3Showed && manaHero >= minManaHero3) { button3.enabled = true; } else { button3.enabled = false; }
            if (hero4Showed && manaHero >= minManaHero4) { button4.enabled = true; } else { button4.enabled = false; }
        }
        else
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
            if (hero3Showed && manaHero >= minManaHero3) { button3.enabled = true; } else { button3.enabled = false; }
            if (hero4Showed && manaHero >= minManaHero4) { button4.enabled = true; } else { button4.enabled = false; }
            if (enemyShowed) StartCoroutine(showEnemy());
        }

        
        timer += Time.deltaTime;
        manaHero += Time.deltaTime * manaLevelHero;
        textTime.text = "Waktu: "+timer.ToString("0");
        textMana.text = "Mana : " + manaHero.ToString("0");
        if (pauseGame == true)
        {
            pauseImage.SetActive(true);
            Time.timeScale = 0;
            //gameObject.GetComponent("MouseLook"). = false;
        }
        else
        {
            pauseImage.SetActive(false);
            Time.timeScale = 1;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (pauseGame) { pauseImage.SetActive(false); } else { Application.LoadLevel("level"); }
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY)
                    {
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeValue > 0)
                        {
                            //textSwipe.text = "Ke Atas"; Debug.Log("Ke Atas");
                        }
                        else if (swipeValue < 0)
                        {
                            //textSwipe.text = "Ke Bawah"; Debug.Log("Ke Bawah");
                        }
                    }

                    float swipeDistHorizontal = (new Vector3(0, touch.position.x, 0) - new Vector3(0, startPos.x, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0)
                        {
                            //textSwipe.text = "Ke Kanan"; Debug.Log("Ke Kanan");
                            gameObject.transform.Translate(Vector3.left * 10 * Time.deltaTime);
                        }
                        else if (swipeValue < 0)
                        {
                            gameObject.transform.Translate(Vector3.right * 10 * Time.deltaTime);
                            //textSwipe.text = "Ke Kiri"; Debug.Log("Ke Kiri");
                        }
                    }
                    break;
            }
        }
    }

    public void pause()
    {
        pauseGame = true;
    }

    public void lanjutkan()
    {
        pauseGame = false;
    }
    public void metu(int id)
    {
        StartCoroutine(showHero(id));
    }

    IEnumerator showHero(int id)
    {
        if (id == 1)
        {
            manaHero -= minManaHero1;
            Instantiate(hero1);
            hero1Showed = false;
            yield return new WaitForSeconds(loadTimeHero1);
            hero1Showed = true;
        }
        else if (id == 2)
        {
            manaHero -= minManaHero2;
            Instantiate(hero2);
            hero2Showed = false;
            yield return new WaitForSeconds(loadTimeHero2);
            hero2Showed = true;
        }
        else if (id == 3)
        {
            manaHero -= minManaHero3;
            Instantiate(hero3);
            hero3Showed = false;
            yield return new WaitForSeconds(loadTimeHero3);
            hero3Showed = true;
        }
        else if (id == 4)
        {
            manaHero -= minManaHero4;
            Instantiate(hero4);
            hero4Showed = false;
            yield return new WaitForSeconds(loadTimeHero4);
            hero4Showed = true;
        }
    }

    IEnumerator showEnemy()
    {
        Instantiate(enemy4);
        enemyShowed = false;
        yield return new WaitForSeconds(showSpeed);
        enemyShowed = true;
    }
}
