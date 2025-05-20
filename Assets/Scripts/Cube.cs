using UnityEngine;

public class Cube : MonoBehaviour
{
    private const string RunningKey = "IsRunning";
    private const string DieKey = "Die";
    
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            _animator.SetBool(RunningKey, true);
        
        if(Input.GetKeyDown(KeyCode.S))
            _animator.SetBool(RunningKey, false);
        
        if(Input.GetKeyDown(KeyCode.Space))
            _animator.SetTrigger(DieKey);
    }
}
