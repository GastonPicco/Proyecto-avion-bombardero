using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Ataque")]

    [Space]

    [SerializeField] GameObject Proyectil;
    GameObject ProyectilPrefab;
    [SerializeField] GameObject forward, down;
    private Vector3 localForward, localDown;
    Rigidbody ProyectilRB;

    private float timerAtaque;
    [Space]
    [Space]
    [Header("Otros")]

    [Space]

    [SerializeField] GameObject MotorR;
    [SerializeField] GameObject MotorL,Body;
    private int vida;
    [SerializeField] GameObject barraVida;

    // Privados [[[]]]

    [Space]
    [Space]

    [Header("Camara")]

    [Space]

    [SerializeField] GameObject cameraControl;
    [SerializeField] Camera mainCamera; //  Camara Principal
    [SerializeField] float distanciacam;
    [SerializeField] LayerMask WaterMask;

    // Privados [[[]]]
    private Ray ray;                    //  rayo camara
    private Vector3 PuntoHit;  //  punto donde se hizo click
    private bool Move = false;

    [Space]
    [Space]

    [Header("Movimiento")]

    [Space]

    [SerializeField] float speedturn, sqrMinDistace;
    [SerializeField] LayerMask IslandMask;
    [SerializeField] float velocidad;

    // Privados[[[]]]
    private float realSpeedTurn;
    private Vector3 destino, sentido;
    [SerializeField]bool RRay,LRay;
    RaycastHit Hit;
    private float _rotation,rotationSpeed,rotationAcelerator;
    





    void Start()
    {
        GameManager.data.player = forward;
    }

    void Update()
    {
        GameManager.data.player = forward;
        localDown = down.transform.position - transform.position;
        localForward = forward.transform.position - transform.position;
        Mouse3D();
        Sentido();
        Movimiento();
        Rotacion();
        CameraControl();
        Zoom();
        Ataque();
        Vida();
    }
    public void Mouse3D()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);               // defino ray como el rayo que sale de la camara
        if (Physics.Raycast(ray, out Hit, 400, WaterMask))   // si apretan click mientras que rayo esta tocando
        {
                PuntoHit = Hit.point;                                            //guardo el punto que choco en una variable llamada PuntoHit
                Move = true;                                                     // el jugador podra moverse
        }
        else
        {
            PuntoHit = new Vector3(0, 0, 0);
        }
        PuntoHit.y = transform.position.y;
    }

    public void Sentido()
    {           
        sentido = PuntoHit - transform.position;                               //  defino el sentido restando la posicion del jugador al punto seleccionado en la pantalla
        Debug.DrawRay(transform.position, sentido);
    }

    public void Movimiento()
    {
        if (Move)                         
        {
            gameObject.transform.position = transform.position + (transform.forward * velocidad * Time.deltaTime);
        }
        MotorR.transform.Rotate(Vector3.forward * Time.deltaTime * 3000);
        MotorL.transform.Rotate(Vector3.forward * Time.deltaTime * 3000);
    }

    public void Rotacion()
    {
        if (Move)
        {
            _rotation = transform.eulerAngles.y;
            realSpeedTurn = speedturn;
            destino = sentido;
            Quaternion rotation = Quaternion.LookRotation(destino); // crea una variable rotation y le asigna la rotacion de Sentido
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, realSpeedTurn * Time.deltaTime); // transforma la rotacion del jugador suavemente
            rotationSpeed = transform.eulerAngles.y - _rotation;
            if(rotationSpeed < 45 * Time.deltaTime && rotationSpeed > -45 * Time.deltaTime)
            {
                rotationSpeed = 0;
                //Debug.Log(Body.transform.localEulerAngles.z);
                if(Body.transform.localEulerAngles.z > 1 && Body.transform.localEulerAngles.z <= 180)
                {
                    if (rotationAcelerator < 1)
                    {
                        rotationAcelerator += Time.deltaTime;
                    }

                    Body.transform.Rotate(Vector3.forward * Time.deltaTime * -60 * rotationAcelerator);
                }
                else if (Body.transform.localEulerAngles.z < 359 && Body.transform.localEulerAngles.z > 180)
                {
                    if (rotationAcelerator < 1)
                    {
                        rotationAcelerator += Time.deltaTime;
                    }
                    Body.transform.Rotate(Vector3.forward * Time.deltaTime * 60 * rotationAcelerator);
                }
            }      
            else if (rotationSpeed > 0 && (Body.transform.localEulerAngles.z > 300 || Body.transform.localEulerAngles.z < 60))
            {
                rotationAcelerator = 0;
                Body.transform.Rotate(Vector3.forward * Time.deltaTime * -60);
            }
            else if (rotationSpeed < 0 && (Body.transform.localEulerAngles.z < 60 || Body.transform.localEulerAngles.z > 300))
            {
                rotationAcelerator = 0;
                Body.transform.Rotate(Vector3.forward * Time.deltaTime * 60 );
            }
            //Debug.Log(rotationSpeed + " = " + transform.eulerAngles.y + "-" + _rotation);

        }
    }

    public void CameraControl()
    {
        cameraControl.transform.position = transform.position;   
        if (Input.GetKey(KeyCode.Q))
        {
            cameraControl.transform.Rotate(0, -100*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cameraControl.transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
    }
    public void Zoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && cameraControl.transform.localScale.x > 0.3)
        {
            cameraControl.transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cameraControl.transform.localScale.x < 2)
        {
            cameraControl.transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
        }
    }

    public void Ataque()
    {
        timerAtaque += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            
            if(timerAtaque > Random.Range(0.5f,0.3f))
            {
                ProyectilPrefab = Instantiate(Proyectil, (transform.position + Vector3.down), gameObject.transform.rotation);
                ProyectilRB = ProyectilPrefab.GetComponent<Rigidbody>();
                ProyectilRB.AddForce(localForward.normalized * 800 * Random.Range(1.2f, 0.8f));
                ProyectilRB.AddForce(localDown.normalized * 800 * Random.Range(1.2f, 0.8f));
                timerAtaque = 0;
            }
            
            
        }
    }
    public void Vida()
    {
        
        vida = GameManager.data.playerHealt;
        if(vida >= 0)
        {
            barraVida.transform.localScale = new Vector3(vida * 0.1f, 1, 1);
        }
        if (vida <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }
}
