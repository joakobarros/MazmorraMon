using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{

    public Transform Ojos;
    public float rangoVision = 20f;

    public Vector3 offset = new Vector3(0f, 0.75f, 0f);

    private NavMesh navMesh;

    void Awake()
    {
        navMesh = GetComponent<NavMesh>();
    }

    public bool verAlJugador(out RaycastHit hit, bool mirarHaciaElJugador = false)
    {
        Vector3 vectorDireccion;

        if (mirarHaciaElJugador)
        {
            vectorDireccion = (navMesh.perseguirObjetivo.position + offset) - Ojos.position;     
        }

        return Physics.Raycast(Ojos.position, Ojos.forward, out hit, rangoVision) && hit.collider.CompareTag("Player");
    }
}