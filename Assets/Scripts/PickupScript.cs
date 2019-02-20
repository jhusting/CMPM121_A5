using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public DoorScript door;
    public float rotationSpeed = 20;

    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = ps.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime));
    }

    //Collision check and damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.isUp = true;
            ps.Play();
            Destroy(this.gameObject);
        }
    }
}
