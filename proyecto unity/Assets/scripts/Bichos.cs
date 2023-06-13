using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bichos : MonoBehaviour
{
    public float HP;
    public float HPMax;
    public float HPActual;
    public float speed;
    public int prioridad;
    public GameObject bichoEscena;
    public GameObject target;
    public GameObject target2;
    public string jugador;
    public Image vida;
    public bool habilitado = true;
   
    
    void Start()
    {
       
    }

    public void Ataque()
    {
        if (prioridad == 1)
        {
            GameManager.my.Ultimo();
        }

        target.GetComponent<Bichos>().HP -= Random.Range(15, 20);
        target.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color1", 1f);
    }

    public void Ataque2()
    {
        bichoEscena.GetComponent<Bichos>().HP -= Random.Range(15, 20);
        bichoEscena.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color2", 1f);
    }

    public void cambioTarget()
    {
        if (bichoEscena == target)
        {
            bichoEscena = target2;
        }
        else
        {
            bichoEscena = target;
        }
    }

    public void color1()
    {
        target.GetComponent<Renderer>().material.color = Color.white;
    }

    public void color2()
    {
        bichoEscena.GetComponent<Renderer>().material.color = Color.white;
    }
 
 

    void Update()
    {

        vida.fillAmount = (HP) / HPMax;
    }
}
