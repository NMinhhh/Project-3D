using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask whatIsEnemy;
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollision(moveDistance);
        transform.position += transform.forward * moveDistance;
    }

    void CheckCollision(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance,whatIsEnemy,QueryTriggerInteraction.Collide))
        {
            OutHit(hit);
        }
    }

    void OutHit(RaycastHit hit)
    {
        IDamageable damageableObj = hit.collider.GetComponent<IDamageable>();
        if(damageableObj != null)
        {
            damageableObj.TakeHit(damage, hit);
        }
        Destroy(gameObject);
    }

}
