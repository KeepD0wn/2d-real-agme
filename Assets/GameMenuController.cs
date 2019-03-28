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
    int lvlMenu=0;
    float soundVolume;

    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("savedSoundVolume"))  //при первом запуске у него не будет ключа и будет использоваться значение по умолчанию
        {                                                      
            PlayerPrefs.SetFloat("savedSoundVolume",0.1f); //после 1 запуска эта часть кода никогда не будет выполняться
        }
       soundSlider.value= PlayerPrefs.GetFloat("savedSoundVolume");  //загружаю значение громкости        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                OnPause();
                lvlMenu++;
                Debug.Log(lvlMenu.ToString());
            }
            else if (Time.timeScale == 0 && lvlMenu == 1)
            {
                OnResume();
                lvlMenu--;
                Debug.Log(lvlMenu.ToString());
            } 
            else if (Time.timeScale == 0 && lvlMenu == 2)
            {
                menu.SetActive(true);
                settings.SetActive(false);
                lvlMenu--;
                Debug.Log(lvlMenu.ToString());
            }
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
        lvlMenu++;
        Debug.Log(lvlMenu.ToString());
    }

    /// <summary>
    /// вызывать когда меняется ползунок громкости музыки
    /// </summary>
    public void OnChangeSoundLoud()
    {        
       PlayerPrefs.SetFloat("savedSoundVolume", soundSlider.value); //сохраняю значение громкости после изменения
        GameObject.FindGameObjectWithTag("GOD").GetComponent<AudioSource>().volume = soundSlider.value;     // зависимость громкости от ползунка в меню  
    }

    public void OnSettingsOff()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        lvlMenu--;
        Debug.Log(lvlMenu.ToString());
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
