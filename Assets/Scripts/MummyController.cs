using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{
    public bool bActive;
    public PlayerController player;
    public float viewAngle;

    private EntityHealth health;
    private bool bMoving;
    private Animator animator;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EntityHealth>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        bMoving = false;
        viewAngle = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        if(bActive)
        {
            bMoving = !InView() || health.health < 75f;
            if (bMoving)
            {
                //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime);
                rb.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime));
                transform.LookAt(player.transform.position);
                animator.SetBool("Moving", true);
            }
            else
                animator.SetBool("Moving", false);
        }
    }

    bool InView()
    {
        RaycastHit hit;
        Vector3 Start = transform.position;
        Start.y += .5f;

        //Debug.DrawRay(Start, (player.transform.position - transform.position) * 50f, Color.red, 20, true);
        if(Physics.Raycast(new Ray(Start, (player.transform.position - transform.position) * 50f), out hit, Mathf.Infinity, LayerMask.GetMask("Default")))
        {
            if (hit.transform.tag != "Player")
                return false;

            Quaternion rotation = Quaternion.LookRotation(transform.position - player.transform.position);

            //float diff = player.transform.rotation.eulerAngles.y - rotation.eulerAngles.y;
            float diff = Mathf.DeltaAngle(player.transform.rotation.eulerAngles.y, rotation.eulerAngles.y);
            if ((diff < viewAngle && diff > 0) || (diff > -viewAngle && diff < 0))
            {
                return true;
            }
        }
        else
            Debug.Log("Didn't hit anything somehow");

        return false;
    }
}
