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

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int damage = 10;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
