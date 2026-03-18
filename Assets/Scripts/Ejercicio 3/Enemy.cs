/*
🎮 Sistema de Enemigo con Vida
Crea una clase Enemy que tenga un atributo de vida. 
Implementa un método para recibir daño y otro para 
morir cuando su vida llegue a cero,eliminando el 
objeto del juego.
*/

using System.Timers;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enemy : MonoBehaviour
{
    public int life = 50;
    //private bool Hisfile = true;

    void Start()
    {
        
    }    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || "Bullet")
        {
            life -= 10;
            print($"El enemigo tiene {life} de vida");

            if (life<=0) 
            { 
                print($"El enemigo ha muerto");
                Destroy(gameObject);
            }            
        }        
    }




}
