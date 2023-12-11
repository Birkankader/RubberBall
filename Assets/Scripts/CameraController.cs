using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.position = new Vector3(player.position.x, player.position.y,transform.position.z);
    }
}
