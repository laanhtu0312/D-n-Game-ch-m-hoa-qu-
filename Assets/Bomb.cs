// Bomb.cs
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Destroy(gameObject);
            GameManager.Instance.HitBomb();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
