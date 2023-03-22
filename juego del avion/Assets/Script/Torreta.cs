using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [SerializeField] GameObject torreta;
    GameObject target;
    [SerializeField] GameObject Proyectil,cañon;
    private float cadencia;


    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.data.player;
    }

    // Update is called once per frame
    void Update()
    {
        torreta.transform.LookAt(target.transform.position);
        //Debug.Log("Distancia" + (target.transform.position - transform.position).magnitude);
        cadencia += Time.deltaTime;
        if ((target.transform.position - transform.position).magnitude < 160 && cadencia > 0.2)
        {           
            Instantiate(Proyectil,cañon.transform.position,torreta.transform.rotation);
            cadencia = 0;
        }
    }
}
