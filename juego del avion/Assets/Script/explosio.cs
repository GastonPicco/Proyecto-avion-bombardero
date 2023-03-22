using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosio : MonoBehaviour
{
    // Start is called before the first frame update
    bool start;
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            transform.localScale += new Vector3(60f * Time.deltaTime, 60f * Time.deltaTime, 60f * Time.deltaTime);
            if (transform.localScale.x > 21)
            {
                start = false;
            }
        }
        else
        {
            transform.localScale -= new Vector3(20f * Time.deltaTime, 20f * Time.deltaTime, 20f * Time.deltaTime);
            if (transform.localScale.x < 0)
            {
                Destroy(gameObject);
            }
        }


    }
}
