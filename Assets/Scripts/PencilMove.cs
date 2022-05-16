using UnityEngine;

public class PencilMove : MonoBehaviour
{
    public bool pencilCanMove;
    public RaycastHit hit;
    private void Update()
    {
        if (pencilCanMove)
        {
            transform.Translate(-Vector3.up * 10 * Time.deltaTime, Space.Self);
            if (Mathf.Abs(hit.transform.position.x) > 10)
            {
                pencilCanMove = false;
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
