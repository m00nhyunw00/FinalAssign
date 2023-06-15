using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighting : MonoBehaviour
{
    public GameObject Light_On, Light_Off;
    public string OnOffKey;

    // Start is called before the first frame update
    void Start()
    {
        Light_On.SetActive(false);
        Light_Off.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.inputString.ToLower() == OnOffKey.ToLower())
            {
                if (Light_On.activeSelf == true)
                {
                    Light_On.SetActive(false);
                    Light_Off.SetActive(true);
                }
                else
                {
                    Light_On.SetActive(true);
                    Light_Off.SetActive(false);
                }
            }
        }
    }
}
