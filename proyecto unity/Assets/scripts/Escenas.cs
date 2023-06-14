using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Escenas : MonoBehaviour
{
    public Material material;
    private DNA DNA;
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

    public void escenaFinal()
    {
        SceneManager.LoadScene("end");
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name == "Player")
        {
            escenaCombate();
        }
    }

}
