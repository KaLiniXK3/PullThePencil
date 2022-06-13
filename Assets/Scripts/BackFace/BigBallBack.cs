using UnityEngine;

public class BigBallBack : MonoBehaviour
{
    public SpawnBall spawnBall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pencil"))
        {
            spawnBall.SmallBallSpawner();
            Destroy(gameObject);
        }
    }
}
