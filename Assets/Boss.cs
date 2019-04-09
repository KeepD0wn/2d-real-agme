using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    int healthPoints=100;    
    [SerializeField] GameObject canvasSlider;
    [SerializeField] Slider slider;

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
            }
            healthPoints = value;
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        slider.value = HealthPoints;

        if (HealthPoints<=0)
        {
            Destroy(gameObject);
            OffSlider(); 
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthPoints -= 5;            
        }
    }
       
    void OffSlider()
    {
        canvasSlider.SetActive(false);
    }
}
