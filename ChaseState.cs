using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Start Chasing");

        // Assuming you have an 'Animator' component attached to the 'Enemy' GameObject
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        
        if (enemyAnimator != null)
        {
            enemyAnimator.SetTrigger("ChaseState");
        }
        else
        {
            Debug.LogError("Animator component not found on Enemy GameObject.");
        }
    }

    public void UpdateState(Enemy enemy)
    {
        if (enemy.player != null)
        {
            enemy.NavMeshAgent.destination = enemy.player.transform.position;
            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) > enemy.ChaseDistance)
            {
                enemy.SwitchState(enemy.PatrolState);
            }
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Stop Chasing");
    }
}


