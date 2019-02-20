using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChange : MonoBehaviour
{
    public Camera oldCam;
    public Camera newCam;
    public PlayerController player;
    public MummyController mum1;
    public MummyController mum2;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //oldCam.gameObject.SetActive(false);
            //newCam.gameObject.SetActive(true);
            mum1.bActive = true;
            mum2.bActive = true;
            //player.fixedCam = newCam;
        }
    }
}
