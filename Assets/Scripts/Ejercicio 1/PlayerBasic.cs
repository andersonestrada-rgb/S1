/*
 1️ 🎮Sistema de Jugador Básico
Crea una clase Player que tenga atributos 
básicos como nombre, vida y velocidad. 
Implementa métodos para moverse y recibir 
daño. El jugador debe poder desplazarse en 
el eje X y reducir su vida cuando recibe daño.
*/

using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerBasic : Player
{   
    void Start()
    {        
        print($"Hola {Name}");
    }
     
    void Update()
    {
        
    }
      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBallet")
        {
            life -= 10;
            print($"Tienes {life} puntos de vida");

            if (life <= 0)
            {
                print($"Has muerto");
                Destroy(gameObject);
            }
        }
    }
}
