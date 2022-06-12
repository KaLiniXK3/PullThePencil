using UnityEngine;
using System.Collections;
public class ThrowPen : MonoBehaviour
{
    [SerializeField] GameObject penPrefab;
    [SerializeField] GameObject spawnBall;
    [SerializeField] GameManager gameManager;
    [SerializeField] Camera cam;
    [SerializeField] float shootSpeed;
    RaycastHit hit;
    Vector3 direction;
    bool canSpawn = true;
    [SerializeField] float spawnCoolDown;
    public int ballAmount;
    private void Start()
    {
        ballAmount = spawnBall.gameObject.transform.childCount;
    }
    private void Update()
    {
        Debug.Log(ballAmount);
        if (ballAmount == 0 && !gameManager.levelCompleted)
        {
            gameManager.levelCompleted = true;
            gameManager.LevelCompleteEvents();
        }

        if (!Input.GetMouseButtonDown(0)) return;
        if (canSpawn) StartCoroutine(IEThrowPen());

    }

    IEnumerator IEThrowPen()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            direction = hit.point - transform.position;
        }
        GameObject pen = Instantiate(penPrefab, transform.position, penPrefab.transform.rotation) as GameObject;
        Rigidbody penRb = pen.GetComponent<Rigidbody>();
        pen.transform.up = direction;
        pen.GetComponent<ThrowPenEvent>().throwPen = gameObject.GetComponent<ThrowPen>();
        penRb.velocity = direction * shootSpeed * Time.deltaTime;
        canSpawn = false;
        yield return new WaitForSeconds(spawnCoolDown);
        canSpawn = true;
    }
}
