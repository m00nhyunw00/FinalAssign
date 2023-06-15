using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class week5_animation : MonoBehaviour
{
    Animator Anim;
    public string PlayKey, PauseKey;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString.ToLower() == PlayKey.ToLower())
        {
            Anim.speed = 1.0f;
        }
        if(Input.inputString.ToLower() == PauseKey.ToLower())
        {
            Anim.speed = 0.0f;
        }
    }
}
