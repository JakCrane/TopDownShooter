using UnityEngine;

public class SpawningZombiesPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public float waitTime = 1;
    private int spawnInterval;
    private int counter;

    public bool spawningNew = true;
    // Start is called before the first frame update
    void Awake()
    {
        counter = 0;
        spawnInterval = Random.Range(300, 500);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter * waitTime > spawnInterval && spawningNew) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            counter = 0;
            spawnInterval = Random.Range(300, 500);
        } else {
            counter++;
        }
        //Debug.Log(rnd);
    }
}
