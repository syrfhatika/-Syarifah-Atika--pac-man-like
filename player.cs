using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rigidBody;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;

    private void Awake()
    {
        
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 horizontalDirection = horizontal * _camera.right;
        Vector3 verticalDirection = vertical * _camera.forward;
        verticalDirection.y = 0;
        horizontalDirection.y = 0;
        Vector3 movementDirection = horizontalDirection+verticalDirection;
        _rigidBody.velocity = movementDirection* _speed *Time.fixedDeltaTime;
    }
}
