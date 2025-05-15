using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Vector3 jumpForce;
    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
    }
}
