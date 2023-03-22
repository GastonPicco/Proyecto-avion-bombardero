using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilContrl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {
            Instantiate(explosion, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, new Vector3 (transform.position.x,0,transform.position.z),Quaternion.identity);
        Destroy(gameObject);
    }
}
