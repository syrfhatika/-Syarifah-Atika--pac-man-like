using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickableManager : MonoBehaviour
{
    [SerializeField]private player _player;
    private List<pickable> _pickableList = new List<pickable>();
    [SerializeField] private ScoreManager _scoreManager;

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
	_scoreManager.SetMaxScore(_pickableList.Count);
    }

    private void OnPickablePicked(pickable pickable)
    {
        _pickableList.Remove(pickable);
        Destroy(pickable.gameObject);
        Debug.Log("Pickable List: " + _pickableList.Count);

        if (_pickableList.Count <= 0)
        {
            SceneManager.LoadScene("winpage");
        }

	if (pickable.PickableType == PickableType.PowerUp)
	{
		_player?.PickPowerUp();

	}
	
	if (_scoreManager != null)

	{

	      _scoreManager.AddScore(1);

	}
	
	
    }
}
