using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateHeart : MonoBehaviour
{

    GameObject[] go;
    [SerializeField] GameObject heart;

    // Use this for initialization
    void Start()
    {
        SearchForHearts(); //потому что для первой сцены событие не происходит
        SceneManager.activeSceneChanged += OnScenChanged;        
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }

    /// <summary>
    /// вызывается когда меняется сцена
    /// </summary>    
   private void OnScenChanged(Scene current,Scene next)
    {
        SearchForHearts();       
    }

    /// <summary>
    /// ищем пустые сердца и заменяем их настоящими
    /// </summary>
    void SearchForHearts()
    {
        go = GameObject.FindGameObjectsWithTag("life");

        for (int i = 0; i < go.Length; i++)
        {
            Instantiate(heart, new Vector2(go[i].transform.position.x, go[i].transform.position.y), Quaternion.identity);
            Destroy(go[i]);
        }
    }
}
