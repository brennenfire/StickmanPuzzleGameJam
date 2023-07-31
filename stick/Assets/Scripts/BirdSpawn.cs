using System.Collections;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    [SerializeField] GameObject bird;

    void Start()
    {
        SpawnBird();
    }

    void SpawnBird()
    {
        StartCoroutine(WaitToSpawn());
    }

    IEnumerator WaitToSpawn()
    {
        var wait = Random.Range(2, 10);
        float x = Random.Range(-2, 5);
        float y = Random.Range(-2, 5);
        var pos = new Vector3(x, y, 0);
        
        yield return new WaitForSeconds(wait);
        Instantiate(bird, transform.position + pos, transform.rotation);
        SpawnBird();
    }
}
