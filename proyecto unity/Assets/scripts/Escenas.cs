using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Escenas : MonoBehaviour
{
    public Material material;
    private DNA DNA;
    public int contar = 0;
    public void escenaInicio()
    {
        SceneManager.LoadScene("start");
    }
    public void escenaMapa()
    {
        SceneManager.LoadScene("map");
    }

    public void escenaCombate()
    {
        DNA = this.GetComponent<DNA>();
        material.color = new Color(DNA.r, DNA.g, DNA.b);
        SceneManager.LoadScene("escena1");
    }

    public void escenaCombate2()
    {
     
        SceneManager.LoadScene("escena2");
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name == "Player" && contar == 0)
        {
   
            escenaCombate(); 
        }
        else
        {
            
            escenaCombate2();
        }   
    }
}