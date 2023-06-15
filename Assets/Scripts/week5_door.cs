using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class week5_door : MonoBehaviour
{
    public GameObject DoorContainer;
    Animator DoorContainerAnim;
    void Start()
    {
        DoorContainerAnim = DoorContainer.GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            print("check1");
            DoorContainerAnim.SetInteger("Control", 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            print("check2");
            DoorContainerAnim.SetInteger("Control", 2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            DoorContainerAnim.SetInteger("Control", 1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            DoorContainerAnim.SetInteger("Control", 2);
        }
    }
}
