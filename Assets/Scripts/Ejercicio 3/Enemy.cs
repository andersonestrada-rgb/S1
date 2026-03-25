/*
🎮 Sistema de Enemigo con Vida
Crea una clase Enemy que tenga un atributo de vida. 
Implementa un método para recibir daño y otro para 
morir cuando su vida llegue a cero,eliminando el 
objeto del juego.
*/

using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enemy : MonoBehaviour
{
    public int life = 50;
    private int pointsForDeath = 10;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 3f;

    [SerializeField] private GameObject bulletParent;
        [SerializeField] private GameObject BulletPrefab;

    private Vector3 startPosition;
    private int direction = 1; // 1 = derecha, -1 = izquierda

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Shoot());
    }

    void Update()
    {
        Move();      
    }

    IEnumerator Shoot()
    {
                while (true)
        {
            ShootProyectile();
            yield return new WaitForSeconds(2f);         
        }
    }

    public void ShootProyectile()
    {
        GameObject bullet = Instantiate(BulletPrefab, bulletParent.transform);
        bullet.transform.position = transform.position;
    }

    public void Move()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        if (transform.position.x >= startPosition.x + distance) //izquierda
        {
            direction = -1;
        }
        else if (transform.position.x <= startPosition.x - distance) //derecha
        {
            direction = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;

        if (tag == "Player" || tag == "Bullet")
        {
            life -= 10;
            print($"El enemigo tiene {life} de vida");

            if (life<=0) 
            { 
                print($"El enemigo ha muerto");
                Destroy(gameObject);
                Player.score += pointsForDeath;
                print($"+ {pointsForDeath}");
                print($"Puntaje total: {Player.score}");
            }            
        }
    }
}
