using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatforms = new List<Transform>();

    public float offSet;

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < platforms.Count; i++)
        {
           Transform p = Instantiate(platforms[i], new Vector3(-0.94f, -0.2f, i * 179.36f), transform.rotation).transform;
           currentPlatforms.Add(p);
           offSet += 179.36f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
    }

    void Update()
    {
        float distance = player.position.z - currentPlatformPoint.position.z;

        if(distance >= 20)
        {
            Reclycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
        }
    }

    private void Reclycle(GameObject plataform)
    {
        plataform.transform.position = new Vector3(-0.94f, -0.2f, offSet);
        offSet += 179.36f;
    }
}
