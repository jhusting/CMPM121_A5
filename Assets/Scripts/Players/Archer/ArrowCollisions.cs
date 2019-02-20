using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour {

    public float m_lifetime = 1;

    // Use this for initialization
    void Start () {
    }

    //Collision check and damage
    private void OnTriggerEnter(Collider other) {
        //print(other);  DEBUG

        if (other.gameObject.tag == "Enemies")
        {
            print("HITTING ENEMY");
            if (other.gameObject.GetComponent<EntityHealth>() != null)
            {
                if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(25))
                {
                    Destroy(other.gameObject);
                }
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            /*print("HITTING PLAYER");
            if (other.gameObject.GetComponent<EntityHealth>() != null)
            {
                if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(20))
                {
                    Destroy(other.gameObject);
                }
            }*/
        }
    }
    
    public void fire()
    {
        Destroy(gameObject, m_lifetime);  //kills the arrow after an amount of time

    }
}
