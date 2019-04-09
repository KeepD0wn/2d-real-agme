using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class heroScript : MonoBehaviour
{
    Rigidbody2D hero;
    Animator anim;       
    Vector2 moveVector;
    float moveSpeed = 4f;
    static int healthPoints=100;
    public static bool watchRight=true;
    AudioSource audio;
    [SerializeField] GameObject bullet;

    public static heroScript instance = null;
    bool grounded=true;
    float ratio = (float)Screen.height / Screen.width; // коэф отношения экрана выс/шир  
    
    private void Awake()
    {     
        
    }

    void Move()
    {
        moveVector = Vector2.zero;
        moveVector.x = Input.GetAxis("Horizontal")*moveSpeed;
        moveVector.y = 0;

        hero.MovePosition(hero.position + moveVector * Time.fixedDeltaTime);
        
    }

    
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        //var l = (GameObject)Resources.Load("pref/Сердце");        //работа с папкой Resourses
        // Instantiate(l,new Vector2(-5,2),Quaternion.identity);     

        // тут определяем зону видимости в зависимости от разрешения экрана
        float f = 1920 * ratio;
        float ortSize = f / 150f;
        Camera.main.orthographicSize = ortSize;
                
        hero = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();                       
    }

    // Update is called once per frame
       

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("ReloadLvl", 1);
        }

        if (gameObject.transform.position.y > 10)
        {
            gameObject.transform.position = new Vector2(-7f, 1f);        //возвращает героя на место при падении вниз или взлёте
                                                                         // на определённые координаты
        }
        else if (gameObject.transform.position.y < -20)
        {
            gameObject.transform.position = new Vector2(-7f, 1f);

        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("beg", 1);                //вызов анимации простоя из аниматора
        }
        else
        {
            Flip();
            anim.SetInteger("beg", 2);             //анимация бега
        }

        if (grounded == true)
        {
            hero.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, hero.velocity.y);
           // Move();
        }        
    }

    public int HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            if (value > 100) value = 100;
            if (value <= 0)
            {
                value = 0;
                Invoke("ReloadLvl", 1);
            }
            healthPoints = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.tag == "Finish")
        {
            if (SceneManager.GetActiveScene().name == "2d")
                SceneManager.LoadScene("level2");
            else
                SceneManager.LoadScene("2d");
        }


        if (collision.gameObject.tag == "land")
        {
            grounded = true;
            Debug.Log("is grounded");
        }

        if (collision.gameObject.tag == "life")
        {           
            audio.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            HealthPoints -= 25;
        }        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "land")
        {
            grounded = true;
            Debug.Log("is grounded");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "land")
        {
            grounded = false;
            Debug.Log("is ungrounded");
        }
    }

    private void OnGUI()                   // интерфейс HP
    {
       GUIStyle style = new GUIStyle();
        style.fontSize = 38;        
        GUI.Box(new Rect(0,0,300,90), "Life = " + HealthPoints,style);
    }

    /// <summary>
    /// отражения персонажа при развороте
    /// </summary>
    void Flip()  
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            watchRight = true;
        }
           
        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            watchRight = false;
        }
           
    }

    void NewHP()
    {
        healthPoints = 100;
    }

    void ReloadLvl()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        NewHP();
    }

    void Jump()
    {
        if (grounded == true)
        {
           hero.velocity = new Vector2(hero.velocity.x,9f);            
           grounded = false;
            //hero.AddForce(transform.up * 10f, ForceMode2D.Impulse);            
        }        
    }       

    
}
