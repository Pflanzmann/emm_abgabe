using UnityEngine;
public class RandomSpawner : MonoBehaviour {

    [SerializeField] private GameObject spawnable;

    [Space] [SerializeField] private float spawnAreaMinX = 10;
    [SerializeField] private float spawnAreaMaxX = 10;

    [Space] [SerializeField] private float spawnAreaMaxZ = 10;
    [SerializeField] private float spawnAreaMinZ = 10;

    [SerializeField] private float spawnInterval = 2;
    private float spawnTimer = 0;

    private void Update() {
        spawnTimer += Time.deltaTime;
        if(spawnTimer < spawnInterval)
            return;

        spawnTimer = 0;

        var spawnPositionX = Random.Range(spawnAreaMinX, spawnAreaMaxX);
        var spawnPositionZ = Random.Range(spawnAreaMinZ, spawnAreaMaxZ);

        Instantiate(spawnable, new Vector3(spawnPositionX, 0f, spawnPositionZ), Quaternion.identity);
    }
}