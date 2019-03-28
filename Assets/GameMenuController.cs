using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour {

    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] Slider soundSlider;
    [SerializeField] GameObject god;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                OnPause();
            else
                OnResume();            
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

    public void OnSettings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void OnSoundLoud()
    {
        GameObject.FindGameObjectWithTag("GOD").GetComponent<AudioSource>().volume = soundSlider.value;     
    }

    public void OnSettingsOff()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }

    public void OnPause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
