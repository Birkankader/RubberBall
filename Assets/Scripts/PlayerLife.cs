using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rigidbody;
    private Vector3 startPos;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rigidbody.isKinematic = true;
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        anim.SetTrigger("DeathTrigger");
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        anim.SetTrigger("RespawnTrigger");
        transform.position = startPos;
        rigidbody.isKinematic = false;
        rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Checkpoint"))
        {
            startPos = transform.position;
        }
    }

}
