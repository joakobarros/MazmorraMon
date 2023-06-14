using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Escenas : MonoBehaviour
{
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
        SceneManager.LoadScene("escena1");
    }

    public void escenaFinal()
    {
        SceneManager.LoadScene("end");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            escenaCombate();
        }
    }

}
