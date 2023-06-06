using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager my;
    public bool myTurno = true;
    public GameObject Acciones;
    public GameObject[] bichos;
    public Image[] barrasHP; 

    void Awake()
    {
        my = this;
    }
    void Start()
    {
        
    }

    public void Luchar()
    {
        if (bichos [0].GetComponent<Bichos>().speed > bichos[1].GetComponent<Bichos>().speed)
        {
            bichos[0].GetComponent<Bichos>().prioridad = 1;
            bichos[1].GetComponent<Bichos>().prioridad = 0;
            bichos[0].GetComponent<Bichos>().Ataque();

        }
        else
         {
            bichos[1].GetComponent<Bichos>().prioridad = 1; 
            bichos[0].GetComponent<Bichos>().prioridad = 0;
            bichos[1].GetComponent<Bichos>().Ataque();
        }
        
    }

    public void Ultimo()
    {
        if (bichos[0].GetComponent<Bichos>().prioridad == 0)
        {
            bichos[0].GetComponent<Bichos>().Ataque();
        }

        if (bichos[1].GetComponent<Bichos>().prioridad == 0)
        {
            bichos[1].GetComponent<Bichos>().Ataque();
        }
    }
       
        void Update()
    {
        
    }
}
