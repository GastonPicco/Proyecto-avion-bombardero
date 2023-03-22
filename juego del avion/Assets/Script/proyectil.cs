using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    public float velocidad;
    public GameObject exp; 
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.AddForce(new Vector3(Random.Range(-.1f,0.1f)*3000,0, Random.Range(-0.1f, 0.1f)*3000));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime * 5);        
        if(transform.position.y > 160)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        GameManager.data.playerHealt = GameManager.data.playerHealt - 1;
        Instantiate(exp, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
