using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificios : MonoBehaviour
{
    public GameObject PrefabCasaDerrumbada;
    bool OffCode;
    // Start is called before the first frame update
    void Start()
    {
        OffCode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("exp")&& !OffCode)
        {
            OffCode = true;
            Destroy(gameObject);

            Instantiate(PrefabCasaDerrumbada,transform.position,Quaternion.identity);           
            GameManager.data.torresRestantes -= 1;
            Debug.Log(gameObject.name + "fue derrumbada");

        }
    }
    

}
