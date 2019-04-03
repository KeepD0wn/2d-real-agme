using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHero : MonoBehaviour {

    GameObject player;
    
	// Use this for initialization
	void Start () {
        FindPlayer();
        
	}
	
	// Update is called once per frame
	void LateUpdate () {

        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -30) ;
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");       
    }
}
