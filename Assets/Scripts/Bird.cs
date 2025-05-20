using UnityEngine;
using UnityEngine.Serialization;

public class Bird : MonoBehaviour
{ 
    [Header("Jump Settings")]
    [SerializeField] private Vector3 _jumpForce = new Vector3(0, 10, 0);
    [SerializeField] private int _movePower = 7;
    [SerializeField] private ParticleSystem _jumpEffect;
    [SerializeField] private ParticleSystem _dieEffect;
    
    public int VerticalJumps { get; private set; }
    public int HorizontalJumps { get; private set; }
    
    private Rigidbody _rigidbody;

    private float _defaultScale;
    private float _targetScale;
    private float _additiveScalePerJump = .25f;

    private float MaxScale => _defaultScale * 2;

    private void Awake()
    {
        _defaultScale = _targetScale = transform.localScale.x;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateScale();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseTargetScale();
            Jump();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow)) 
            MoveLeft();

        if (Input.GetKeyUp(KeyCode.RightArrow)) 
            MoveRight();
        
    }

    private void IncreaseTargetScale()
    {
        _targetScale += _additiveScalePerJump;

        if (_targetScale > MaxScale)
            _targetScale = MaxScale;
    }

    private void UpdateScale()
    {
        if (_targetScale > _defaultScale)
            _targetScale -= Time.deltaTime;
        
        transform.localScale = new Vector3(_targetScale, _targetScale, _targetScale);
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
        _jumpEffect.Play();
        VerticalJumps++;
    }

    public void RestJumpCounter()
    {
        HorizontalJumps = 0;
        VerticalJumps = 0;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = false;
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        _dieEffect.transform.position = transform.position;
        _dieEffect.Play();
    }

    public void Stop() => 
        _rigidbody.isKinematic = true;
}
