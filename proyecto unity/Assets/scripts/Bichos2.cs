using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bichos2 : MonoBehaviour
{
    public float HP;
    public float HPMax;
    public float speed;
    public int prioridad;
    public GameObject target;
    public Image vida;
    public int count = 0;
    public Material material;

    void Start()
    {
        vida.GetComponent<Image>().color = Color.green;
    }

    public void Ataque()
    {
        if (prioridad == 1)
        {
            GameManager2.my.Ultimo();
        }

        target.GetComponent<Bichos2>().HP -= Random.Range(15, 25);
        target.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color", 0.5f);
    }

    public void Ataque2()
    {
        if (prioridad == 1)
        {
            GameManager2.my.Ultimo2();
        }

        target.GetComponent<Bichos2>().HP -= Random.Range(30, 40);
        target.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color", 0.5f);
    }

    public void AtaqueEnemigo()
    {
        if (prioridad == 1)
        {
            GameManager2.my.Ultimo();
        }

        target.GetComponent<Bichos2>().HP -= Random.Range(15, 27);
        target.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color", 0.5f);
    }

    public void AtaqueEnemigo2()
    {
        if (prioridad == 1)
        {
            GameManager2.my.Ultimo2();
        }

        target.GetComponent<Bichos2>().HP -= Random.Range(15, 27);
        target.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color", 0.5f);
    }

    public void color()
    {
        this.GetComponent<Renderer>().material.color = material.color;
    }

    void Update()
    {
        vida.fillAmount = (HP) / HPMax;

        if (HP <= 40 && HP > 20)
        {
            vida.GetComponent<Image>().color = Color.yellow;
        }

        if (HP <= 20 && HP > 0)
        {
            vida.GetComponent<Image>().color = Color.red;
        }

        if(HP <= 0)
        {
            count = 1;
        }
 
    }
}
