using UnityEngine;


public class CheckBallSpawn : MonoBehaviour
{
    public SpawnBall spawnBall;
    bool colliding;
    bool rbKinematic;
    bool canControl;
    bool checkedCollision;
    private void Update()
    {
        if (!colliding && !rbKinematic && canControl)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rbKinematic = true;
            spawnBall.CheckBallAmount();
        }
        if (colliding)
        {
            SpawnNew();
        }
        else if (!colliding && checkedCollision)
        {
            canControl = true;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explose Ball"))
        {
            Debug.Log("Colliding");
            Destroy(collision.gameObject);
            colliding = true;
        }
        checkedCollision = true;
    }

    public void SpawnNew()
    {
        spawnBall.SingleSpawn();
        colliding = false;
        canControl = true;
    }


}
