using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    Canvas gameMenu;
	// Use this for initialization
	void Start () {
        gameMenu = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                OnPause();
            else
                OnResume();
           // gameMenu.enabled = !gameMenu.enabled;
        }
	}

    public void OnTotalExit()
    {
        Application.Quit();
    }

    public void OnMenuExit()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPause()
    {
        gameMenu.enabled = !gameMenu.enabled;
        Time.timeScale = 0;        
    }

    public void OnResume()
    {
        gameMenu.enabled = !gameMenu.enabled;
        Time.timeScale = 1;       
    }
}
