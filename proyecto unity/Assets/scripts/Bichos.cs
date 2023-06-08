using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bichos : MonoBehaviour
{
    public float HP;
    public float HPMax;
    public float speed;
    public int prioridad;
    public GameObject bichoEscena;
    public GameObject target;
    public GameObject target2;
    public string jugador;
    public Image vida;
   
    
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

    }

    public void Ataque2()
    {
        bichoEscena.GetComponent<Bichos>().HP -= Random.Range(40, 50);

    }


    void Update()
    {
        if (gameObject.CompareTag("Bicho1") == true)
        {
            bichoEscena = target;
        }

        if (prioridad == 1)
        {
            bichoEscena = target2;
        }


        vida.fillAmount = (HP) / HPMax;
    }
}
