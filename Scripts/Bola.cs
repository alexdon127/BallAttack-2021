using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    //Velocidad de la bola
    public float velocidad = 0f;
    private Vector3 moveVelocidad;
    private Rigidbody rb;
    public float speed = 0f;
    public float acc = 0f;
    private float movLateral = 12.5f;
    public bool MI = false;
    public bool MD = false;

    //Para el deslizamiento
    //Vector2 PosicionInicial;
    [SerializeField] float SwipeMinX;

    //GameObjects
    public GameObject PanelMu; 

    //Puntuación
    public Text scoreText;
    public float score;
    //Valor de lo que suma a la puntuación
    public float scoreObj = 250;
    public float scoreObs = 200;
    public float scoreM = 100;

    //Monedas
    public Text monedaText;
    public float moneda;
    private float valorMoneda = 10;

    //Para guardar las variables
    private string monedaPrefsName = "Moneda";

    //Para los temporizadores de los powerup
    public float tempInv = 0.0f;
    public bool esInvencible;
    public float tempSpeed = 0.0f;
    public float tempIman = 0.0f;
    public GameObject iman;
    public float tempDoble = 0.0f;

    // Valor de incremento y decremento
    float incremento = 50f;
    float decremento = 1.5f;

    // Valor minimo de la imagen escalada
    float min = 1f;
    // Valor maximo de la imagen escalada
    float max = 70f;

    // Efecto de particulas tras recoger un objeto
    public GameObject efectoParticula;

    //Posicion ejes
    float x, y, z;

    //Para la activacion de sonidos
    public GameObject gameController;

    private void Awake()
    {
        LoadData();
    }

    void Start()
    {
        //Iniciar el movimiento de la bola
        rb = GetComponent<Rigidbody>();

        //Iniciar la animacion

        //Iniciar los textos
        scoreText.text = score.ToString();
        monedaText.text = moneda.ToString();

        //Puntuacion a 0 cada nivel
        score = 0;

        //Busqueda del GameObject para el Iman
        iman = GameObject.Find("Iman");

        //Movimiento inicial
        velocidad = 3f;
        acc = 1.5f;

        //Para los sonidos buscamos su gameObject
        gameController = GameObject.FindGameObjectWithTag("AC");
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocidad;
    }

    void Update()
    {
       
        //Movimiento
        Movimiento();
        Atraer();
        Escudo();
        DoblePunt();

        //Moverse al pulsar el botón izquierdo
        if (MI)
        {
            transform.Translate(Vector3.left * movLateral * Time.deltaTime);
        }

        //Moverse al pulsar el botón derecho
        if (MD)
        {
            transform.Translate(Vector3.right * movLateral * Time.deltaTime);
        }

        scoreText.text = score.ToString();
        monedaText.text = moneda.ToString();

        //Ejes
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
       
    }

    void Movimiento()
    {
        speed = velocidad * acc;
        velocidad += 1 * Time.deltaTime;
        acc += 1 * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (tempSpeed <= 0)
        {
            if (speed >= 10)
            {
                speed = 10;
            }
            if (acc >= 3.5f)
            {
                acc = 3.5f;
            }
            if (velocidad >= 3.5f)
            {
                velocidad = 3.5f;
            }
        }
        if (tempSpeed > 0)
        {
            tempSpeed -= 1 * Time.deltaTime;
            speed = 15;
            acc = 5;
            velocidad = 10;
        }
        /*if (speed >= 10)
        {
            speed = 10;
        }
        if (acc>=5)
        {
            acc = 5;
        }
        if (velocidad >=5)
        {
            velocidad = 5;
        }*/
    }

    void Atraer()
    {
        if (tempIman > 0)
        {
            tempIman -= 1 * Time.deltaTime;
            iman.SetActive(true);
        }
        if (tempIman <= 0)
        {
            tempIman = 0;
            iman.SetActive(false);
        }
    }
    void Escudo()
    {
        if (tempInv <= 0)
        {
            tempInv = 0;
            esInvencible = false;

        }
        if (tempInv > 0)
        {
            tempInv -= 1 * Time.deltaTime;
            esInvencible = true;
        }
    }

    void DoblePunt()
    {
        if (tempDoble > 0)
        {
            tempDoble -= 1 * Time.deltaTime;
            //Aumentar el valor de la puntuación recogida (PuntuacionA x 2)
            scoreObj = 500;
            scoreObs = 400;
            scoreM = 200;
        }
        if (tempDoble <= 0)
        {
            tempDoble = 0;
            scoreObj = 250;
            scoreObs = 200;
            scoreM = 100;
}
    }

    public void MovIzquierda()
    {

        MI = true;

    }

    public void MovIzquierdaOff()
    {
        MI = false;
    }

    public void MovDerecha()
    {
        MD = true;
    }

    public void MovDerechaOff()
    {
        MD = false;
    }


    //Colisiones con los objetos
    void OnTriggerEnter(Collider other)
    {
        //Accion que hace que cuando la bola choque con un objeto aumente su tamaño
        if (other.tag == "Obj")
        {
            
            //Aumetar el tamaño de la escala de la bola si no es el maximo ya
            transform.localScale = new Vector3(
               x + incremento < max ? x + Time.deltaTime * incremento : max, 
               y + incremento < max ? y + Time.deltaTime * incremento : max,
               z + incremento < max ? z + Time.deltaTime * incremento : max
               );

            //Aumentar puntuación
            score += scoreObj;

            //Destruir el objeto
            Destroy(other.gameObject);
        }

        //Accion que hace que cuando la bola choque con un obstaculo disminuya su tamaño
        if (other.tag == "Obs")
        {
            //Activamos su sonido
            gameController.SendMessage("SonarColision");

            //Comprobamos si es invencible o no
            if (esInvencible == true)
            {
                Destroy(other.gameObject);
                return;
            }
            if (esInvencible == false)
            {
                velocidad = 0;
                acc = 0;
                //Disminuir puntuación
                if (score > 0)
                {
                    score -= scoreObs;
                    if (score <= 0)
                    {
                        PanelMu.SetActive(true);
                        if (Time.timeScale == 1)
                        {    //si la velocidad es 1
                            Time.timeScale = 0;//que la velocidad del juego sea 0
                        }
                    }
                }
                else if (score <= 0)
                {
                    PanelMu.SetActive(true);
                    if (Time.timeScale == 1)
                    {    //si la velocidad es 1
                        Time.timeScale = 0;//que la velocidad del juego sea 0
                    }
                }

                //Disminuye el tamaño de la bola si no es el minimo ya
                transform.localScale = new Vector3(
                    x - decremento > min ? x - decremento : min,
                    y - decremento > min ? y - decremento : min,
                    z - decremento > min ? z - decremento : min
                    );
                Destroy(other.gameObject);
            }
        }

        if (other.tag == "Iman")
        {
            //Particulas al recogerlo
            //Instantiate(efectoParticula, transform.position, transform.rotation);

            //Activamos su sonido
            gameController.SendMessage("SonarItem1");

            //Añadir tiempo
            tempIman += 5.0f;
            //Destruir el objeto
            Destroy(other.gameObject);

        }

        if (other.tag == "x2")
        {
            //Particulas al recogerlo
            //Instantiate(efectoParticula, transform.position, transform.rotation);

            //Activamos su sonido
            gameController.SendMessage("SonarItem1");

            //Añadir tiempo
            tempDoble += 4.0f;
            //Destruir el objeto
            Destroy(other.gameObject);

        }

        if (other.tag == "escudo")
        {
            //Particulas al recogerlo
            //Instantiate(efectoParticula, transform.position, transform.rotation);

            //Activamos su sonido
            gameController.SendMessage("SonarItem2");

            //Añadir tiempo
            tempInv += 3.0f;
            //Destruir el objeto
            Destroy(other.gameObject);
        }

        if (other.tag == "velocidad")
        {
            //Particulas al recogerlo
            //Instantiate(efectoParticula, transform.position, transform.rotation);

            //Activamos su sonido
            gameController.SendMessage("SonarItem2");

            //Añadir tiempo
            tempSpeed += 2.0f;
            //Destruir el objeto
            Destroy(other.gameObject);

        }
        if (other.tag == "moneda")
        {
            //Activamos su sonido
            gameController.SendMessage("SonarMoneda");

            //Aumentar la puntuación
            score += scoreM;

            //Aumentar el contador de monedas 
            moneda += valorMoneda;

            //Destruir el objeto
            Destroy(other.gameObject);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "paredI")
        {
            MI = false;
        }
        if (other.tag == "paredD")
        {
            MD = false;
        }
    }

    private void OnDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetFloat(monedaPrefsName, moneda);
    }

    private void LoadData()
    {
        moneda = PlayerPrefs.GetFloat(monedaPrefsName, 0);
    }
}












/*
. 問
╔[]╝ ADR
.╝╚
*/