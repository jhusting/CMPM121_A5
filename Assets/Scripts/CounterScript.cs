using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    public int numDestroyed;
    Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        numDestroyed = 0;
        displayText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        numDestroyed++;
        displayText.text = "Targets Hit: " + numDestroyed;
    }
}
