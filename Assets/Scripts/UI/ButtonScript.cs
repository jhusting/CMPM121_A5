using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SwitchPerspective);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SwitchPerspective()
    {
        if(firstPersonCamera.gameObject.activeSelf)
        {
            firstPersonCamera.gameObject.SetActive(false);
            thirdPersonCamera.gameObject.SetActive(true);
        }
        else
        {
            firstPersonCamera.gameObject.SetActive(true);
            thirdPersonCamera.gameObject.SetActive(false);
        }
    }
}
