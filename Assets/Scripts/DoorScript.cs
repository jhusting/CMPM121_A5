using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isUp = false;
    public Vector3 UpOffset;

    private Vector3 TargetPosition;
    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = transform.position + UpOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUp)
        {
            Vector3 currPosition = transform.position;
            currPosition = Vector3.Lerp(currPosition, TargetPosition, 0.8f * Time.deltaTime);
            transform.position = currPosition;
        }
    }
}
