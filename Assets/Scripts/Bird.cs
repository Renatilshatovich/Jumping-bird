using UnityEngine;
using UnityEngine.Serialization;

public class Bird : MonoBehaviour
{ 
    [Header("Jump Settings")]
    [SerializeField] private Vector3 _jumpForce = new Vector3(0, 10, 0);
    [SerializeField] private int _movePower = 7;     
    
    public int VerticalJumps { get; private set; }
    public int HorizontalJumps { get; private set; }
    
    private Rigidbody _rigidbody;
    

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody>();

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) 
            Jump();
        
        if (Input.GetKeyUp(KeyCode.LeftArrow)) 
            MoveLeft();

        if (Input.GetKeyUp(KeyCode.RightArrow)) 
            MoveRight();
    }

    private void MoveRight()
    {
        _rigidbody.velocity = new Vector3(+_movePower, 0, 0);
        HorizontalJumps++;
    }

    private void MoveLeft()
    {
        _rigidbody.velocity = new Vector3(-_movePower, 0, 0);
        HorizontalJumps++;
    }

    private void Jump()
    {
        _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
        VerticalJumps++;
    }

    public void RestJumpCounter()
    {
        HorizontalJumps = 0;
        VerticalJumps = 0;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = false;
    }


    public void Stop() => 
        _rigidbody.isKinematic = true;
}
