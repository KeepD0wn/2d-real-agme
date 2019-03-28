using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dingBoss : MonoBehaviour {

    bool push;
    Rigidbody2D boss;

    // Use this for initialization
    void Start()
    {
        boss = GetComponent<Rigidbody2D>();
        StartCoroutine(Dode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Dode()
    {
       while (true)
       {
            if (push)
            {
                boss.AddForce(transform.right * Random.Range(-0.9f, 1f), ForceMode2D.Impulse);                
                push = false;
            }
            else
            {
                boss.AddForce(transform.right * Random.Range(-0.2f, 0.3f), ForceMode2D.Impulse);                
            }
            yield return new WaitForSeconds(0.15f);
       }
    }
    
}
