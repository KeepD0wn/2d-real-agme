using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public float cooldown = 0.2f;
    float currentCooldown;
    Vector2 dire;
    
    [SerializeField] GameObject bullet;

	// Use this for initialization
	void Start () {
        
    }
	
    

	// Update is called once per frame
	void LateUpdate () {

       
       
      

        if (Input.GetMouseButton(0) && CanShoot()==true)
        {
            Shoot();
        }        

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
	}

    bool CanShoot()
    {
        if (currentCooldown <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }       
    }

    void Shoot()  //Transform enemy
    {
        currentCooldown = cooldown;
        GameObject newBullet = Instantiate(bullet);
        if (heroScript.watchRight == true)
        {
            newBullet.transform.position = gameObject.transform.position + new Vector3(1f, 0.12f, 0); //магический вектор для респа пули прямо в дуле
        }
        else
        {
            newBullet.transform.position = gameObject.transform.position + new Vector3(-1f, 0.12f, 0); //магический вектор для респа пули прямо в дуле
        }
        
    }

    void SearchTarget()
    {

    }
}
