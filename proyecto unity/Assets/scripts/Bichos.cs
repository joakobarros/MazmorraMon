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
            GameManager.my.Ultimo();
        }

        target.GetComponent<Bichos>().HP -= Random.Range(15, 20);
        target.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color", 0.5f);
    }

    public void Ataque2()
    {
        if (prioridad == 1)
        {
            GameManager.my.Ultimo2();
        }

        target.GetComponent<Bichos>().HP -= Random.Range(20, 30);
        target.GetComponent<Renderer>().material.color = Color.red;
        Invoke("color", 0.5f);
    }

    public void AtaqueEnemigo()
    {
        if (prioridad == 1)
        {
            GameManager.my.Ultimo();
        }

        target.GetComponent<Bichos>().HP -= Random.Range(10, 15);
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
