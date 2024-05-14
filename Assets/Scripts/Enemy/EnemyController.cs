using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyController : MonoBehaviour {

    public float lookradius = 10f;

    Transform target;
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        float distance = Vector3.Distance(target.position, transform.position);
        
        if(distance < lookradius)
        {
            agent.SetDestination(target.position);
        }

        if (agent.remainingDistance<2f)
        {
            animator.SetFloat("MovementSpeed", 0);
        }
        else
        {
            animator.SetFloat("MovementSpeed", 1);
        }
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);    

    }

}
