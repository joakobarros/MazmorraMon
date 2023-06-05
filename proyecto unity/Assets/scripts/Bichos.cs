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
    public GameObject target;
    public string jugador;
    public Image vida;
   
    
    void Start()
    {
       
    }

    public void FinAtaque()
    {
        //target.GetComponent<Renderer>().material.color = Color.red;
        //target.GetComponent<Bichos>().HP -= 20;
    }
   

    public void Ataque()
    {
        if (prioridad == 1)
        {
            GameManager.my.Ultimo();
        }

        target.GetComponent<Bichos>().HP -= Random.Range(15,20);
    }
    
   
    void Update()
    {
        vida.fillAmount = (HP) / HPMax;
    }
}
