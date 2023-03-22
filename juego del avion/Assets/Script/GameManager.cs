using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager data;
    public GameObject player , ganado , destruido;
    public int playerHealt;
    public GameObject[] Structures;
    public float Radio;
    int random;
    public int torresRestantes = 13;
    public float timer;

    private void Awake()
    {
        if (data == null)
        {
            data = this;
        }
        else
        {
            if (data == this)
            {
                
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        playerHealt = 10;
        Radio = 500;
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//1
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//2
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//3
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//4
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//5
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//6
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//7
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//8
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//9
        Radio = 100;
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//10
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//11
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//12
        randomNum(0, 2);
        Instantiate(Structures[random], new Vector3(Random.Range(Radio, -Radio), 0, Random.Range(Radio, -Radio)), Quaternion.identity);//13
    }

    // Update is called once per frame
    void Update()
    {
        if (torresRestantes <= 0)
        {
            ganado.SetActive(true);
            timer += Time.deltaTime;

            if(timer > 3)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (playerHealt <= 0)
        {
            destruido.SetActive(true);
            timer += Time.deltaTime;

            if (timer > 3)
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }
    private void randomNum(int num1,int num2)
    {
        random = Random.Range(num1, num2);
    }
}
