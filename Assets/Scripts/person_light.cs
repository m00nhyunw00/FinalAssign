using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class person_light : MonoBehaviour
{

    public GameObject SpotLight;
    public string OnOffKey;

    // Start is called before the first frame update
    void Start()
    {
        SpotLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.inputString.ToLower() == OnOffKey.ToLower())
            {
                if (SpotLight.activeSelf == false)
                {
                    SpotLight.SetActive(true);
                }
                else
                {
                    SpotLight.SetActive(false);
                }
            }
        }
    }
}
