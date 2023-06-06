using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoNormal: MonoBehaviour
{
    public Transform[] WayPoints;

    private NavMesh navMesh;
    private MaquinaDeEstados maquinaDeEstados;
    private Vision vision;
    
    
    private int siguienteWayPoint;

    void Awake()
    {
        navMesh = GetComponent<NavMesh>();
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        vision = GetComponent<Vision>(); 
    }

    void Update()
    {
    
        RaycastHit hit;
        if(vision.verAlJugador(out hit))
        {
            navMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }

        if (navMesh.HemosLlegado())
        {
            siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
            ActualizarWayPointDestino();
        }

    }

    void OnEnable()
    {
        ActualizarWayPointDestino();
    }

    void ActualizarWayPointDestino()
    {
        navMesh.ActualizarPuntoDestinoNMA(WayPoints[siguienteWayPoint].position);
    }

    public void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);

        }
    }
}