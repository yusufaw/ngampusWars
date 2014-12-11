using UnityEngine;
using System.Collections;

public class Senjata : MonoBehaviour
{

    public float speed = 1, timer = 0;
    public float destroyDistance = 20;
    public bool isHero;
    private Vector3 startPos;
    public float minJarak = 5;
    void Start()
    {
        startPos = transform.position;
        if (isHero)
        {
            rigidbody2D.AddForce(Vector2.right * 1f);
        }
        else
        {
            rigidbody2D.AddForce(Vector3.left * 1f);
        }
        //rigidbody2D.AddForce(Vector2.up * 3f);
        //GameObject gun = GameObject.FindGameObjectWithTag("hero");
        //gameObject.transform.position = gun.transform.position;
    }

    void OnEnable()
    {
        
        Invoke("Destroy", 10f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            Vector3 diff = startPos - transform.position;
            float jarak = diff.magnitude;
            if (jarak < minJarak)
            {
                rigidbody2D.AddForce(Vector2.up * 2.5f);
            }
            //rigidbody2D.AddForce(Vector2.up * 3f);
            if (isHero)
            {
                rigidbody2D.AddForce(Vector2.right * 1f);
            }
            else
            {
                //rigidbody2D.AddForce(Vector3.left * 3f);

                gameObject.transform.Translate(Vector3.left * 2 * Time.deltaTime);
            }
        }
    }

    
}
