/*
🎮 Sistema de disparo
Crea una clase Bullet que se mueva 
hacia adelante constantemente. 
Cuando colisione con un enemigo, 
debe aplicar daño al enemigo y 
destruirse a sí misma.
*/

using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    int damage = 10;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Shoot()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


}
