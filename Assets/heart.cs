using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class heart : MonoBehaviour {
        
    // Use this for initialization
    void Start () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            collision.gameObject.GetComponent<heroScript>().HealthPoints += 25;
            Destroy(gameObject);           
        }                         
    }

    // Update is called once per frame
    void Update () {
		
	}
}
