using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private BaseState _currentState;
    public PatrolState PatrolState = new PatrolState();
    public ChaseState ChaseState = new ChaseState();
    public RetreatState RetreatState = new RetreatState();
    [SerializeField] public List<Transform> Waypoints = new List<Transform>();
    [SerializeField] public float ChaseDistance;
    [SerializeField] public player player; 
    [HideInInspector] public Animator Animator;
    [HideInInspector] public NavMeshAgent NavMeshAgent;
    private bool _isPowerUpActive = false;

    public void SwitchState(BaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

    private void Awake()
    {
        _currentState = PatrolState;
        _currentState.EnterState(this);
        NavMeshAgent = GetComponent<NavMeshAgent>();
	Animator = GetComponent<Animator>();
    }

    public void StartRetreating()
    {
	SwitchState(RetreatState);
    }

    public void StopRetreating()
    {
	SwitchState(PatrolState);
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.UpdateState(this);
        }
    }
    
    public void Dead()
    {

	Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
	if (_isPowerUpActive)
        {
	   if (collision.gameObject.CompareTag("Enemy"))
	   {
		collision.gameObject.GetComponent<Enemy>().Dead();
	   }

	}

	   if(_currentState != RetreatState)
	   {
	   	if (collision.gameObject.CompareTag("player"))
	   	{
		     collision.gameObject.GetComponent<player>().Dead();
	    	}
	}

     }

}

 
