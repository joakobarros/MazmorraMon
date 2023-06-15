using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{

    public static GameManager2 my;
    public bool myTurno = true;
    public GameObject Acciones;
    public GameObject CartelVictoria;
    public GameObject CartelDerrota;
    public GameObject[] bichos;
    //public Image[] barrasHP;
    

    void Awake()
    {
        my = this;
    }
    void Start()
    {
    }

    public void Luchar()
    {
        if (bichos[0].GetComponent<Bichos2>().speed > bichos[1].GetComponent<Bichos2>().speed)
        {
            bichos[0].GetComponent<Bichos2>().prioridad = 1;
            bichos[1].GetComponent<Bichos2>().prioridad = 0;
            bichos[0].GetComponent<Bichos2>().Ataque();

        }
        else
         {
            bichos[1].GetComponent<Bichos2>().prioridad = 1; 
            bichos[0].GetComponent<Bichos2>().prioridad = 0;
            bichos[1].GetComponent<Bichos2>().AtaqueEnemigo();
        }
        
    }
    public void Luchar2()
    {
        if (bichos[0].GetComponent<Bichos2>().speed > bichos[1].GetComponent<Bichos2>().speed)
        {
            bichos[0].GetComponent<Bichos2>().prioridad = 1;
            bichos[1].GetComponent<Bichos2>().prioridad = 0;
            bichos[0].GetComponent<Bichos2>().Ataque2();

        }
        else
        {
            bichos[1].GetComponent<Bichos2>().prioridad = 1;
            bichos[0].GetComponent<Bichos2>().prioridad = 0;
            bichos[1].GetComponent<Bichos2>().AtaqueEnemigo2();
        }

    }

    public void Ultimo()
    {
        if (bichos[0].GetComponent<Bichos2>().prioridad == 0)
        {
            bichos[0].GetComponent<Bichos2>().Ataque();
        }

        if (bichos[1].GetComponent<Bichos2>().prioridad == 0)
        {
            bichos[1].GetComponent<Bichos2>().AtaqueEnemigo();
        }

    }

    public void Ultimo2()
    {
        if (bichos[0].GetComponent<Bichos2>().prioridad == 0)
        {
            bichos[0].GetComponent<Bichos2>().Ataque2();
        }

        if (bichos[1].GetComponent<Bichos2>().prioridad == 0)
        {
            bichos[1].GetComponent<Bichos2>().AtaqueEnemigo2();
        }

    }

    void Update()
    {
        if (bichos[0].GetComponent<Bichos2>().count == 1)
        {
            CartelDerrota.SetActive(true);
            Acciones.SetActive(false);
        }

        if (bichos[1].GetComponent<Bichos2>().count == 1)
        {
            CartelVictoria.SetActive(true);
            Acciones.SetActive(false);
            
        }

    }
}
