using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int collectibles = 0;
    private Text collectibleText;
    private Animator animator;
    private GameObject collectibleObject;
    private void Start()
    {
        collectibleText = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
        collectibleObject = GameObject.FindWithTag("Collectible");
        animator = collectibleObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Collectible"))
        {
            collectibles++;
            animator.SetTrigger("CollectableTrigger");
            Destroy(col.gameObject);
            collectibleText.text = "Collectible : " + collectibles;
        }
    }
}
