using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour
{
    [SerializeField]private player _player;
    private List<pickable> _pickableList = new List<pickable>();

    private void Start()
    {
        InitPickableList();
    }

    private void InitPickableList()
    {
        pickable[] pickableObjects = GameObject.FindObjectsOfType<pickable>();

        for (int i = 0; i < pickableObjects.Length; i++)
        {
            _pickableList.Add(pickableObjects[i]);
            pickableObjects[i].OnPicked += OnPickablePicked;
        }

        Debug.Log("Pickable List: " + _pickableList.Count);
    }

    private void OnPickablePicked(pickable pickable)
    {
        _pickableList.Remove(pickable);
        Destroy(pickable.gameObject);
        Debug.Log("Pickable List: " + _pickableList.Count);

        if (_pickableList.Count <= 0)
        {
            Debug.Log("Win");
        }

	if (pickable.PickableType == PickableType.PowerUp)
	{
		_player?.PickPowerUp();

	}
    }
}
