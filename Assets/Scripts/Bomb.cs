using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float radius;
    [SerializeField] float upForce;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Active"))
        {
            StartCoroutine(BombExplosion());
        }
    }
    IEnumerator BombExplosion()
    {
        yield return new WaitForSeconds(0.8f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
