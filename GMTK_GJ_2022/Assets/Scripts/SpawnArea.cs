using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Vector3 regionSize;
    [SerializeField] float cooldown = 5f;

    float lastSpawn = 0f;

    void Update()
    {
        if(Time.time - lastSpawn > cooldown)
        {
            spawn();

            lastSpawn = Time.time;
        }
    }

    void spawn()
    {
        Vector3 position = new Vector3();
        position.x = transform.position.x;
        position.y = transform.position.y;
        position.z = transform.position.z;

        position.x += Random.Range(-regionSize.x/2, regionSize.x/2);
        position.y += Random.Range(-regionSize.y/2, regionSize.y/2);
        position.z += Random.Range(-regionSize.z/2, regionSize.z/2);

        GameObject go = Instantiate(prefab, position, new Quaternion());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, regionSize);
    }
}
