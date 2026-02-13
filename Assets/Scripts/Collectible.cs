using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
           player.apples++;
            Destroy(gameObject);
        }
    }


}

