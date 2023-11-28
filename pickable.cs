using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class pickable : MonoBehaviour
{
    [SerializeField] public PickableType PickableType;
    public Action<pickable> OnPicked;  // Corrected the event name to match the declaration

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnPicked != null)
            {
                OnPicked(this);
            }
        }
    }
}


