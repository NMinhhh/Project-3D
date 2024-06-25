using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : LivingEntity
{
    NavMeshAgent agent;
    Transform target;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        float timer = .25f;
        while(target != null)
        {
            Vector3 targetPos = new Vector3 (target.position.x, 0, target.position.z);
            if(!dead)
                agent.SetDestination(targetPos);
            yield return new WaitForSeconds(timer);

        }
    }
}
