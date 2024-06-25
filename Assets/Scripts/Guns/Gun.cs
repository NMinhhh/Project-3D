using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Projectile bulletPref;
    [SerializeField] private float speed;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float cooldown;
    private float startTimer;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Shoot()
    {
        if(Time.time > startTimer + cooldown)
        {
            startTimer = Time.time;
            Projectile projectile = Instantiate(bulletPref, spawnPoint.position, spawnPoint.rotation) as Projectile;
            projectile.SetSpeed(speed);
        }
        
    }
}
