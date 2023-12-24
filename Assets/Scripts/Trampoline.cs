using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float pushForce = 250f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
        }
    }

}
