using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion: MonoBehaviour
{
    private Escenas escenas;
    private MaquinaDeEstados maquinaDeEstados;
    private NavMesh navMesh;
    private Vision vision;


    void Awake()
    {
        escenas = GetComponent<Escenas>();
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        navMesh = GetComponent<NavMesh>();
        vision = GetComponent<Vision>();

    }

    void Update()
    {
        RaycastHit hit;

        if(!vision.verAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }

        navMesh.ActualizarPuntoDestinoNavMeshAgent();

    }
    
}