using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    private Vector3 startPos;

    public float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x- repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
