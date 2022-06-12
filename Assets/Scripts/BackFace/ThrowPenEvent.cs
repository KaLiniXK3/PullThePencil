using UnityEngine;

public class ThrowPenEvent : MonoBehaviour
{
    bool canDestroyBall = true;
    public int ballAmount;
    public ThrowPen throwPen;
    private void Update()
    {
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explose Ball") && canDestroyBall)
        {
            Destroy(collision.gameObject);
            canDestroyBall = false;
            throwPen.ballAmount--;
        }
    }
}
