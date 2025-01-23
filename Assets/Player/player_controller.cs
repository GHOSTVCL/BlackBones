using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody rb;
    private Vector3 moveInput;
    private float moveZ;
    private float moveX;

    private bool mirandoDerecha = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        moveInput = new Vector3(moveX, 0f, moveZ);
    }
    private void FixedUpdate()
    {
        Mover();
    }
    private void Mover()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        if(Input.GetKey(KeyCode.A) && mirandoDerecha)
        {
            Flip();
        }
        if(Input.GetKey(KeyCode.D) && !mirandoDerecha)
        {
            Flip();
        }
    }
    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
