using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float velMovimiento;

    public Vector2 sensibilidad;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    public void Update()
    {      
        Movimiento();
        Camara();

    }

    public void Movimiento()
    {    
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;

            rigidbody.velocity = direction * velMovimiento;
        }
    }

    private void Camara()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");
        
        if (hor != 0)
        {
            transform.Rotate(0, hor * sensibilidad.x, 0);
        }
    }
}
