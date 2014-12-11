using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    public float distance = 5, speed = 1, health = 100;
    Animator animator;
    public GameObject senjata;
    public bool mbledos = true;
    public float delayFire;
    public List<GameObject> kumpulanPeluru;
    public int jumlahPeluru = 10;
    public float minJarak = 3;
    public float tembakSpeed = 10;
    private float timer = 0;
    public float waktuTembak = 4;
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

    // Update is called once per frame
    void Update()
    {

        if (health <= 0) Destroy(gameObject);
        GameObject[] players, senjatas;
        players = GameObject.FindGameObjectsWithTag("hero");
        senjatas = GameObject.FindGameObjectsWithTag("EditorOnly");

        Vector3 position = transform.position;
        bool temu = false;
        foreach (GameObject player in players)
        {
            Vector3 dif = player.transform.position - position;
            float curDistance = dif.sqrMagnitude;
            if (curDistance < distance)
            {
                temu = true;
            }
        }
        if (!temu)
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            //if (mbledos)
            //{
            //    StartCoroutine(peluru());
            //}
            
        }
        else
        {
            //animator.SetTrigger("DoSerang");
            //if (mbledos)
            //{
            //    StartCoroutine(peluru());
            //}
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer > waktuTembak)
            {
                //metu();
                timer = 0;
            }
        }
    }

    void metu()
    {
        for (int i = 0; i < kumpulanPeluru.Count; i++)
        {
            if (!kumpulanPeluru[i].activeInHierarchy)
            {
                kumpulanPeluru[i].SetActive(true);
                Vector3 pos = gameObject.transform.position;
                pos.x = gameObject.transform.position.x - 1;
                kumpulanPeluru[i].transform.position = pos;
                break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Kena Tembak");
        //health = health - 30;
        Destroy(collision.gameObject);
    }

    IEnumerator peluru()
    {
        mbledos = false;
        Vector3 pos = gameObject.transform.position;
        pos.x = gameObject.transform.position.x - 1;
        senjata.transform.position = pos;
        Instantiate(senjata);
        //gameObject.audio.Play();

        yield return new WaitForSeconds(delayFire);
        mbledos = true;
    }
}