using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{

    public float distance = 5;
    public float speed = 1;
    public float health = 100;
    Animator animator;
    public GameObject senjata;
    public List<GameObject> kumpulanPeluru;
    public int jumlahPeluru = 10;
    private float timer = 0;
    public float waktuTembak = 4;
    public bool isHero;
    private Senjata senjataScript;

    void Start()
    {
        for (int i = 0; i < jumlahPeluru; i++)
        {
            GameObject objekPeluru = (GameObject)Instantiate(senjata);
            objekPeluru.SetActive(false);
            kumpulanPeluru.Add(objekPeluru);
        }
        animator = transform.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Didn't find Animator!");
        }
    }

    void Update()
    {
        if (health <= 0) {
            for (int i = 0; i < kumpulanPeluru.Count; i++)
            {
                Destroy(kumpulanPeluru[i]);
            }
            Destroy(gameObject); }
        GameObject[] players;
        GameObject gedung;
        if (isHero)
        {
            players = GameObject.FindGameObjectsWithTag("enemy");
            gedung = GameObject.FindGameObjectWithTag("gedung enemy");
        }
        else
        {
            players = GameObject.FindGameObjectsWithTag("hero");
            gedung = GameObject.FindGameObjectWithTag("gedung hero");
        }
        Vector3 position = transform.position;
        bool temu = false;
        foreach (GameObject player in players)
        {
            Vector3 dif = player.transform.position - position;
            float curDistance = dif.sqrMagnitude;
            Debug.Log("Posisi = " + player.transform.position.x);
            Debug.Log("CUR = " + curDistance);
            Debug.Log("DIS = " + distance);
            if (curDistance < distance)
            {
                temu = true;
            }
        }

        Vector3 diffGedung = position - gedung.transform.position;
        float curDistanceGedung = diffGedung.sqrMagnitude;
        //Debug.Log("Gedung = "+curDistanceGedung);
        if (curDistanceGedung < distance) { temu = true; }
        if (!temu)
        {
            bool mlaku = true;
            for (int i = 0; i < kumpulanPeluru.Count; i++)
            {
                if (kumpulanPeluru[i].activeInHierarchy)
                {
                    mlaku = false;
                    break;
                }
            }
            if (mlaku) {
                animator.SetTrigger("DoMlaku");
                if (isHero) { gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime); } else { gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime); } }
        }
        else
        {

            if (timer == 0)
            {
                
                metu();
                animator.SetTrigger("DoSerang");
            }
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer > waktuTembak)
            {
                timer = 0; Debug.Log("haha");
            }
        }
    }

    void metu()
    {
        Senjata senjataSelf;
        Debug.Log("Metoe");
        for (int i = 0; i < kumpulanPeluru.Count; i++)
        {
            if (!kumpulanPeluru[i].activeInHierarchy)
            {
                kumpulanPeluru[i].SetActive(true);
                Vector3 pos = gameObject.transform.position;
                pos.y = gameObject.transform.position.y + 0.4f;
                kumpulanPeluru[i].transform.position = pos;
                senjataSelf = (Senjata)kumpulanPeluru[i].GetComponent("Senjata");
                senjataSelf.startPos = transform.position;
                break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Kena Tembak");
        senjataScript = (Senjata)collision.gameObject.GetComponent("Senjata");
        if (isHero)
        {
            if (!senjataScript.isHero)
            {
                health = health - senjataScript.damage;
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