using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootDirection;
    [SerializeField] float maxShotsPerSecond = 5;


    float lastShotTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time - lastShotTime > (1/maxShotsPerSecond))
        {
            Instantiate(projectile, shootDirection.position, shootDirection.rotation);
            lastShotTime = Time.time;
        }
    }
}
