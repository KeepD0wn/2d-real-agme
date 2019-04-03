using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlyScr : MonoBehaviour {

    float speed = 10f;
    Vector2 dir;    

    private void Awake()
    {       
        CheckHeroAxis();
    }

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {           
        gameObject.transform.Translate(dir*Time.deltaTime);
    }

    /// <summary>
    /// проверяем куда повёрнут персонаж и изменяем направление пули
    /// так же даём ей скорость в нужную сторону
    /// вызываем в старте что бы потом она не поворачивалась и считалась независимым объектом
    /// </summary>
    void CheckHeroAxis()
    {
        if (heroScript.watchRight == true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            dir = new Vector2(speed, 0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            dir = new Vector2(-speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
    }

    

}
