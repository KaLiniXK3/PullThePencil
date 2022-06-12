using UnityEngine;

public class CheckBallSpawn : MonoBehaviour
{
    public SpawnBall spawnBall;
    bool colliding;
    bool rbKinematic;

    private void Update()
    {
        if (!colliding && !rbKinematic)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rbKinematic = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explose Ball"))
        {
            Destroy(collision.gameObject);
            colliding = true;
        }

    }

    public void SpawnNew()
    {
        if (colliding)
        {
            spawnBall.SingleSpawn();
            colliding = false;
        }
    }
}
