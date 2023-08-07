using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private float spawnRate = 3;
    private float timer;
    private float spawnOffset = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPlatform();

        }
    }

    void spawnPlatform()
    {
        timer = 0;

        Vector3 pos = new Vector3(Random.Range(-1*spawnOffset, spawnOffset), transform.position.y, transform.position.z);

        Instantiate(platform, pos, transform.rotation);

    }
}
