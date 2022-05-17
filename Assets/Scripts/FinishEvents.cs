using UnityEngine;

public class FinishEvents : MonoBehaviour
{
    public int completedBallCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Active"))
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            completedBallCount++;
        }
    }
}
