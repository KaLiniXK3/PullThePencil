using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    float boundariesX = 2.3f;
    float boundariesY = 3.35f;
    float posZ = 0.4f;
    [SerializeField]
    int ballAmount = 12;
    private void Start()
    {
        Spawner();
    }
    void Spawner()
    {
        for (int i = 0; i < ballAmount; i++)
        {
            float randomPosX = Random.Range(-boundariesX, boundariesX);
            float randomPosY = Random.Range(-boundariesY, boundariesY);
            Vector3 randomSpawnPos = new Vector3(randomPosX, randomPosY, posZ);
            GameObject ball = Instantiate(ballPrefab, randomSpawnPos, Quaternion.identity) as GameObject;
            Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            ball.GetComponent<Renderer>().material.color = randomColor;
            ball.GetComponent<CheckBallSpawn>().spawnBall = GetComponent<SpawnBall>();
            ball.GetComponent<CheckBallSpawn>().SpawnNew();
            ball.transform.parent = transform;
        }
    }

    public void SingleSpawn()
    {
        float randomPosX = Random.Range(-boundariesX, boundariesX);
        float randomPosY = Random.Range(-boundariesY, boundariesY);
        Vector3 randomSpawnPos = new Vector3(randomPosX, randomPosY, posZ);
        GameObject ball = Instantiate(ballPrefab, randomSpawnPos, Quaternion.identity) as GameObject;
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        ball.GetComponent<Renderer>().material.color = randomColor;
        ball.GetComponent<CheckBallSpawn>().spawnBall = GetComponent<SpawnBall>();
        ball.transform.parent = transform;
    }
}
