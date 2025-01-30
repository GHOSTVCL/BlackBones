using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    private bool mirandoDerecha = true;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + 0.04f, player.transform.position.y, player.transform.position.z + 0.05f);
        
    }
    public void FlipAttack()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
