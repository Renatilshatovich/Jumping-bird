using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Bird : MonoBehaviour
{ 
    [SerializeField] private Vector3 _jumpForce;
    private Rigidbody _rigidbody;

    private int _jumpCount;

    public int JumpCount => _jumpCount;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
            _jumpCount++;
        }
    }

    public void RestJumpCounter() => 
        _jumpCount = 0;
}
