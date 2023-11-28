using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private player _player;
    [SerializeField] private float _powerUpDuration;
    private Coroutine _powerUpCoroutine;
    public Action OnPowerUpStart;
    public Action OnPowerUpStop;

    private Enemy _enemy; // Assuming Enemy is the correct script type

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _enemy = GetComponent<Enemy>(); // Replace with the actual type of the Enemy script
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (_player != null)
        {
            _player.OnPowerUpStart += StartRetreating;
            _player.OnPowerUpStop += StopRetreating;
        }
    }

    private IEnumerator StartPowerUp()
    {
        Debug.Log("Start Power Up");
        yield return new WaitForSeconds(_powerUpDuration);
        Debug.Log("Stop Power Up");

        if (OnPowerUpStart != null)
        {
            OnPowerUpStart();
        }

        yield return new WaitForSeconds(_powerUpDuration);
        if (OnPowerUpStop != null && _enemy != null)
        {
            _enemy.StopRetreating(); // Call the appropriate method from the Enemy script
            OnPowerUpStop();
        }
    }

    public void PickPowerUp()
    {
        if (_powerUpCoroutine != null)
        {
            StopCoroutine(_powerUpCoroutine);
        }

        _powerUpCoroutine = StartCoroutine(StartPowerUp());
        Debug.Log("Picked Power Up!");
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 horizontalDirection = horizontal * _camera.right;
        Vector3 verticalDirection = vertical * _camera.forward;
        verticalDirection.y = 0;
        horizontalDirection.y = 0;
        Vector3 movementDirection = horizontalDirection + verticalDirection;
        _rigidBody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
    }

    private void StartRetreating()
    {
        // Implement your logic for starting retreating
    }

    private void StopRetreating()
    {
        // Implement your logic for stopping retreating
    }
}
