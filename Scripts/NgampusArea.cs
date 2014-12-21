using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NgampusArea : MonoBehaviour
{
    public GameObject hero1, hero2, hero3, hero4, pauseImage;
    public GameObject enemy1, enemy2, enemy3, enemy4;
    public static bool pauseGame = false;
    private bool  hero1Showed = true, hero2Showed = true, hero3Showed = true, hero4Showed = true;
    private bool enemy1Showed = true, enemy2Showed = true, enemy3Showed = true, enemy4Showed = true;
    private Vector2 startPos;
    public float minSwipeDistY, minSwipeDistX, loadTimeHero1 = 2, loadTimeHero2 = 2, loadTimeHero3 = 2, loadTimeHero4 = 2;
    public Text textTime, textMana, hasilWaktu, hasilNilai, teksHasil;
    public Button button1, button2, button3, button4;
    public float timer = 0, manaHero = 0, manaEnemy = 0, manaLevelHero = 1, manaLevelEnemy = 1;
    public float showSpeed = 4;
    public float minManaHero1 = 10, minManaHero2 = 30, minManaHero3 = 80, minManaHero4 = 100;
    public float minManaEnemy1 = 10, minManaEnemy2 = 30, minManaEnemy3 = 80, minManaEnemy4 = 100;
    public static bool isMenang;
    public GameObject hasilSelesai;

    public static void selesai(){
        Time.timeScale = 0;
    }
    void Start()
    {
        pauseGame = false;
        button1.enabled = button2.enabled = button3.enabled = button4.enabled = false;
    }

    void Update()
    {
        if (Level.level == 1)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (enemy1Showed) StartCoroutine(showEnemy(1));
        }
        else if (Level.level == 2)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
            if (enemy1Showed) StartCoroutine(showEnemy(1));
            if (enemy1Showed) StartCoroutine(showEnemy(2));
        }
        else if (Level.level == 3)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
            if (hero3Showed && manaHero >= minManaHero3) { button3.enabled = true; } else { button3.enabled = false; }
            if (enemy1Showed) StartCoroutine(showEnemy(1));
            if (enemy1Showed) StartCoroutine(showEnemy(2));
            if (enemy1Showed) StartCoroutine(showEnemy(3));
        }
        else if (Level.level == 4)
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
            if (hero3Showed && manaHero >= minManaHero3) { button3.enabled = true; } else { button3.enabled = false; }
            if (hero4Showed && manaHero >= minManaHero4) { button4.enabled = true; } else { button4.enabled = false; }
            if (enemy1Showed) StartCoroutine(showEnemy(1));
            //if (enemy1Showed) StartCoroutine(showEnemy(2));
            //if (enemy1Showed) StartCoroutine(showEnemy(3));
            //if (enemy1Showed) StartCoroutine(showEnemy(4));
        }
        else
        {
            if (hero1Showed && manaHero >= minManaHero1) { button1.enabled = true; } else { button1.enabled = false; }
            if (hero2Showed && manaHero >= minManaHero2) { button2.enabled = true; } else { button2.enabled = false; }
            if (hero3Showed && manaHero >= minManaHero3) { button3.enabled = true; } else { button3.enabled = false; }
            if (hero4Showed && manaHero >= minManaHero4) { button4.enabled = true; } else { button4.enabled = false; }
            if (enemy1Showed) StartCoroutine(showEnemy(1));
            if (enemy1Showed) StartCoroutine(showEnemy(2));
            if (enemy1Showed) StartCoroutine(showEnemy(3));
            if (enemy1Showed) StartCoroutine(showEnemy(4));
        }

        timer += Time.deltaTime;
        manaHero += Time.deltaTime * manaLevelHero;
        textTime.text = "Waktu: " + timer.ToString("0");
        if (timer < 75)
        {
            hasilNilai.text = "A";
        }
        else if(timer>=75 &&  timer < 90){
            hasilNilai.text = "B+";
        }
        else if (timer >= 90 && timer < 110)
        {
            hasilNilai.text = "B";
        }
        else if (timer >= 110 && timer < 130)
        {
            hasilNilai.text = "C+";
        }
        else if (timer >= 130   && timer < 150)
        {
            hasilNilai.text = "C";
        }
        else if (timer >= 150 && timer < 170)
        {
            hasilNilai.text = "D+";
        }
        else if (timer >= 170)
        {
            hasilNilai.text = "D";
        }
        if (!isMenang)
        {
            teksHasil.text = "Gagal";
            hasilNilai.text = "E";
        }
        else
        {
            teksHasil.text = "Berhasil";
        }

        hasilWaktu.text = timer.ToString("0");
        textMana.text = "Mana : " + manaHero.ToString("0");
        if (pauseGame == true)
        {
            Time.timeScale = 0;
            if (!hasilSelesai.activeInHierarchy) { pauseImage.SetActive(true); }
            
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
                            if (transform.position.x > -9) { 
                                gameObject.transform.Translate(Vector3.left * 10 * Time.deltaTime);
                            }
                        }
                        else if (swipeValue < 0)
                        {
                            if (transform.position.x < 10)
                            {
                                gameObject.transform.Translate(Vector3.right * 10 * Time.deltaTime);
                            }
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
    public void mainMenu()
    {
        pauseGame = false;
        Application.LoadLevel("main");
    }

    public void mainUlang()
    {
        pauseGame = false;
        Application.LoadLevel("play");
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

    IEnumerator showEnemy(int id)
    {
        if (id == 1)
        {
            //manaHero -= minManaHero1;
            Instantiate(enemy1);
            enemy1Showed = false;
            yield return new WaitForSeconds(showSpeed);
            enemy1Showed = true;
        }
        else if (id == 2)
        {
            //manaenemy -= minManaenemy2;
            Instantiate(enemy2);
            enemy2Showed = false;
            yield return new WaitForSeconds(showSpeed);
            enemy2Showed = true;
        }
        else if (id == 3)
        {
            //manaenemy -= minManaenemy3;
            Instantiate(enemy3);
            enemy3Showed = false;
            yield return new WaitForSeconds(showSpeed);
            enemy3Showed = true;
        }
        else if (id == 4)
        {
            //manaenemy -= minManaenemy4;
            Instantiate(enemy4);
            enemy4Showed = false;
            yield return new WaitForSeconds(showSpeed);
            enemy4Showed = true;
        }
    }
}
