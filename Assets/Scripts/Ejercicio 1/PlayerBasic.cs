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

public class PlayerBasic : Player
{
    [SerializeField] private GameObject bulletParent;
        [SerializeField] private GameObject BulletPrefab;

    void Start()
    {        
        print($"Hola {Name}");
    }

    void Update()
    {
        base.Update();
        ShootProyectile();
    }

    protected override void MovementMechanise(Vector2 input)
    {
        // Solo movimiento en X
        Vector2 onlyX = new Vector2(input.x, 0);
        transform.position += (Vector3)onlyX * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
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

    public void ShootProyectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {        
            GameObject bullet = Instantiate(BulletPrefab, bulletParent.transform);           //-> Crear 
            bullet.transform.position = transform.position;                     //Coloca la bala en la posición del player
                                                                            // bullet.transform.up;                                                             //Ajusta el ángulo de la bala a la ubicación del mouse
        }
    }
}
