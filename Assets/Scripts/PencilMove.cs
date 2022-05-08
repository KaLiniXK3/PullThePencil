using UnityEngine;

public class PencilMove : MonoBehaviour
{
    public bool pencilCanMove;

    private void Update()
    {
        //if (pencilCanMove)
        //    Movement();
        //if (!Input.GetMouseButtonDown(0))
        //    return;
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.collider.gameObject == gameObject)
        //    {
        //        pencilCanMove = true;
        //    }
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("WORKEDBLOCKLAYER");
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    public void Movement(RaycastHit hit)
    {
        while (pencilCanMove)
        {
            transform.Translate(-Vector3.up * 10 * Time.deltaTime, Space.Self);
            if (Mathf.Abs(hit.transform.position.x) > 10)
            {
                pencilCanMove = false;
                Destroy(gameObject);

            }
        }
    }
}
