using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EntityHealth : MonoBehaviour
{
    [SerializeField]
    public float health;
    public CounterScript sc;

    private void Awake()
    {
    }

    void Update()
    {
        //print("CURVAL " + health.CurrentVal);
    }


    public bool TakeDamage(float amount)
    {
        health -= amount;

        // Death Check
        if (health <= 0)
        {
            //print(gameObject.tag);
            if(gameObject.tag == "Player")
            {
                SceneManager.LoadScene("DeathScreen");
            }
            //sc.Increment();
            Destroy(this.gameObject);
            return true; //killed em
        }
        return false;
    }
}