using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeart : MonoBehaviour {

    GameObject [] go;    
    [SerializeField] GameObject heart;
    
	// Use this for initialization
	void Start () {
        
        go = GameObject.FindGameObjectsWithTag("life");      
        
        for (int i = 0; i < go.Length; i++)
        {
            Instantiate(heart, new Vector2(go[i].transform.position.x, go[i].transform.position.y), Quaternion.identity);
            Destroy(go[i]);           
        }        
    }    
    
	// Update is called once per frame
	void LateUpdate () {               

    }
}
