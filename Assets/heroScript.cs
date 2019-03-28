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
    public UnityEvent OnEat;
    int doubleJump=0;    
    static int healthPoints=100;

    public static heroScript instance = null;
    bool canJump=true;
    float ratio = (float)Screen.height / Screen.width; // коэф отношения экрана выс/шир  
    
    private void Awake()
    {     
        
    }

    // Use this for initialization
    void Start()
    {
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
        float ortSize = f / 200f;
        Camera.main.orthographicSize = ortSize;
                
        hero = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();                       
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    private void LateUpdate()
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

        hero.velocity = new Vector2(Input.GetAxis("Horizontal") * 10f, hero.velocity.y);

        // hero.MovePosition(new Vector2(Input.GetAxis("Horizontal") * 3f, hero.velocity.y));
        // Vector2 move = new Vector2(Input.GetAxis("Horizontal") * 10f, hero.position.y) * Time.deltaTime;
        // hero.MovePosition(hero.position+move);
    }

    public int HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            if (value >= 100) value = 100;
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
            canJump = true;            
            Debug.Log("is grounded");
        }

        if (collision.gameObject.tag == "life")
        {
            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            HealthPoints -= 25;
        }       
    }    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    
    private void OnGUI()                   // интерфейс HP
    {
        GUI.Box(new Rect(0,0,100,30), "Life = " + HealthPoints);
    }     

    void Flip()  // отражения персонажа при развороте
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0,0,0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
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
        if (canJump == true)
        {
            doubleJump++;
            hero.velocity = new Vector2(hero.velocity.x, 7f);
            if (doubleJump == 2)
            {
                canJump = false;
                doubleJump = 0;
            }          
                              
           //hero.AddForce(transform.up * 10f, ForceMode2D.Impulse);            
        }        
    }   
}
