using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    public GameObject senjata;
    public bool mbledos = true;
    public float distance = 5, speed = 1, delayFire = 1;
    Animator animator;
    void Start()
    {
        Vector3 pos = transform.position;
        pos.y = pos.y + (Random.Range(-1, 1) * 0.1f);
        transform.position = pos;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        animator = transform.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Didn't find Animator!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        Vector3 position = transform.position;
        bool temu = false;
        foreach (GameObject enemy in enemies)
        {
            Vector3 dif = enemy.transform.position - position;
            float curDistance = dif.sqrMagnitude;
            if (curDistance < distance)
            {
                temu = true;
            }
        }

        if (!temu)
        {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            if (mbledos)
            {
                StartCoroutine(peluru());
            }
        }
    }

    IEnumerator peluru()
    {
        senjata.transform.position = gameObject.transform.position;
        Instantiate(senjata);
        //gameObject.audio.Play();
        mbledos = false;
        yield return new WaitForSeconds(delayFire);
        mbledos = true;
    }


}
