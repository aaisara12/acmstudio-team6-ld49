using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootDirection;
    [SerializeField] float maxShotsPerSecond = 5;
    [SerializeField] Animator fantasyAnimator;


    float lastShotTime = 0;

    // Update is called once per frame
    void Update()
    {
        // Super lazy way of preventing player from shooting when not in fantasy mode
        if(GameManager.instance.currentGameMode != GameMode.FANTASY) {return;}


        // This would be better decoupled, but once again not enough time :()
        bool isTryingToShoot = Input.GetMouseButton(0);

        if(isTryingToShoot && Time.time - lastShotTime > (1/maxShotsPerSecond))
        {
            Instantiate(projectile, shootDirection.position, shootDirection.rotation);
            lastShotTime = Time.time;
        }

        // This should definitely be decoupled as a separate animator controller script
        fantasyAnimator.SetBool("isShooting", isTryingToShoot);
        
    }
}
