using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{
    public float velocidadGiroBusqueda = 120f;

    public float duracionBusqueda = 4f;


    private MaquinaDeEstados maquinaDeEstados;
    private NavMesh navMesh;
    private Vision vision;

    private float tiempoActual;
    public float setTime = 4;


    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        navMesh = GetComponent<NavMesh>();
        vision = GetComponent<Vision>();
    }

    void OnEnable()
    {
        navMesh.DetenerNMA();
        tiempoActual = setTime;
    }
   
    void Update()
    {
        tiempoActual -= Time.deltaTime;

        RaycastHit hit;
        if (vision.verAlJugador(out hit))
        {
            navMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
        
        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);

        if(tiempoActual <= 0)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoNormal);
            tiempoActual = setTime;
            return;
        }

    }
}