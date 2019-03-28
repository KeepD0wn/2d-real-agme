using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGOD : MonoBehaviour {

    static int count = 0;
    [SerializeField] GameObject god;

    // Use this for initialization
    void Start()
    {        
        if (count == 0)
        {
            Instantiate(god);
            count++;
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GOD"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
