using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private int value = 1;

    [SerializeField] private float timeToDespawn;


    void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().score += value;
            Destroy(gameObject);
        }
    }

}