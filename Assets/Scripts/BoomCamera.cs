using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomCamera : MonoBehaviour
{
    // focus is the object we want the camera to focus on, to get a better feel the focus location is slightly above the player
    public GameObject focus;
    public PlayerController player;
    public GameObject testEnemy;

    public float rotateSpeed = 2f;
    public float startLength = 4f;
    public float boomLength = 4f;
    public float focusHeight = 1f;
    public bool playerControl = false;

    public bool isLocked;
    private int playerNum;

    private void Start()
    {
        isLocked = false;
        playerNum = player.playerNum;
    }

    private void Update()
    {
        if (!playerControl)
        {
            UpdateFocusLocation();
        }
        UpdateBoomLength();
    }

    // We use late update so all the player calculations are done before the camera calculations
    void LateUpdate ()
    {
        if (Input.GetButtonDown("Lock" + playerNum))
            isLocked = !isLocked;

        if(!isLocked)
            ProcessInput();
        else
        {
            //focus.transform.LookAt(testEnemy.transform);
            Quaternion targetRotation = Quaternion.LookRotation(testEnemy.transform.position - focus.transform.position);

            focus.transform.rotation = Quaternion.Lerp(focus.transform.rotation, targetRotation, 0.05f);

            if (playerNum == 2)
            {
                isLocked = false;
                focus.transform.rotation = targetRotation;
            }
        }

        //Calculate the position of the camera by getting the focus's forward vector,
        // multiplying it by boomLength, then adding it to the focus's position
        transform.position = focus.transform.position + focus.transform.forward * (-1f*boomLength);

        //Make the camera look at the focus
        transform.LookAt(focus.transform);
    }

    private void ProcessInput()
    {
        //Get player inputs for desired horizontal and vertical rotation
        float horizontal = Input.GetAxis("HorizontalCamera" + player.playerNum) * rotateSpeed;
        float vertical = Input.GetAxis("VerticalCamera" + player.playerNum) * rotateSpeed;

        //Get the rotation of the focus
        Vector3 focusRotation = focus.transform.eulerAngles;

        //Add to its vertical rotation the player's input
        float desiredVert = focusRotation.x + vertical;

        //Clamp that number between 345 and 45 
        //The vertical angle of the camera is weird, its between 345 and 360 for when you are looking above the horizon, and 0 and 45 for below
        if (desiredVert > 300)
            desiredVert = Mathf.Clamp(desiredVert, 345f, 460f);
        else if (desiredVert > 35 && desiredVert < 90)
            desiredVert = Mathf.Clamp(desiredVert, -100f, 45f);

        //Horizontal rotation doesn't need to be clamped, want full 360 rotation
        float desiredHoriz = focusRotation.y + horizontal;

        //Alright change the old focusRotation vector3 to what we want now
        focusRotation.x = desiredVert;
        focusRotation.y = desiredHoriz;

        //Trans the focus transform's rotation to our focusRotation value we calculated
        focus.transform.rotation = Quaternion.Euler(focusRotation);
    }

    private void UpdateFocusLocation()
    {
        Vector3 newPosition = player.transform.position;
        newPosition.y += focusHeight;
        focus.transform.position = Vector3.Lerp(focus.transform.position, newPosition, 16f * Time.deltaTime);

        //boomLength = Mathf.Lerp(boomLength, startLength, 8f * Time.deltaTime);
    }

    private void UpdateBoomLength()
    {
        RaycastHit hit;
        Vector3 Start = focus.transform.position;

        //Debug.DrawRay(Start, (transform.position - focus.transform.position), Color.red, boomLength, true);
        if (Physics.Raycast(new Ray(Start, (transform.position - focus.transform.position)), out hit, boomLength, LayerMask.GetMask("Default")))
        {
            boomLength = hit.distance;
        }
        else
        {
            //boomLength = Mathf.Lerp(boomLength, startLength, 8f * Time.deltaTime);
        }

        boomLength = Mathf.Lerp(boomLength, startLength, 3f * Time.deltaTime);
    }
}
