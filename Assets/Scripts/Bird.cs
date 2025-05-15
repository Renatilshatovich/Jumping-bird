using UnityEngine;

public class Bird : MonoBehaviour
{ 
    [SerializeField] private Vector3 _jumpForce;
    private Rigidbody _rigidbody;

    private int _jumpCount;
    private Transform _bird;
    [SerializeField] private int _powerDirection;

    public int JumpCount => _jumpCount;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _bird = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
            _jumpCount++;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _bird.GetComponent<Rigidbody>().velocity = new Vector3(0-_powerDirection, 0, 0);
            _jumpCount+=3;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _bird.GetComponent<Rigidbody>().velocity = new Vector3(0+_powerDirection, 0, 0);
            _jumpCount+=3;
        }
    }

    public void RestJumpCounter() => 
        _jumpCount = 0;
}
