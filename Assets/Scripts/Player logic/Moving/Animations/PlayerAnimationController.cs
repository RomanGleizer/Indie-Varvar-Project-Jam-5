using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(AnimatorTriggers.RightTrigger, true);
            _animator.SetBool(AnimatorTriggers.Idle, false);
            _animator.SetBool(AnimatorTriggers.LeftTrigger, false);
            _animator.SetBool(AnimatorTriggers.DownTrigger, false);
            _animator.SetBool(AnimatorTriggers.UpTrigger, false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool(AnimatorTriggers.LeftTrigger, true);
            _animator.SetBool(AnimatorTriggers.Idle, false);
            _animator.SetBool(AnimatorTriggers.RightTrigger, false);
            _animator.SetBool(AnimatorTriggers.DownTrigger, false);
            _animator.SetBool(AnimatorTriggers.UpTrigger, false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool(AnimatorTriggers.LeftTrigger, false);
            _animator.SetBool(AnimatorTriggers.Idle, false);
            _animator.SetBool(AnimatorTriggers.RightTrigger, false);
            _animator.SetBool(AnimatorTriggers.DownTrigger, true);
            _animator.SetBool(AnimatorTriggers.UpTrigger, false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool(AnimatorTriggers.LeftTrigger, false);
            _animator.SetBool(AnimatorTriggers.Idle, false);
            _animator.SetBool(AnimatorTriggers.RightTrigger, false);
            _animator.SetBool(AnimatorTriggers.DownTrigger, false);
            _animator.SetBool(AnimatorTriggers.UpTrigger, true);
        }
        else
        {
            _animator.SetBool(AnimatorTriggers.Idle, true);
            _animator.SetBool(AnimatorTriggers.RightTrigger, false);
            _animator.SetBool(AnimatorTriggers.LeftTrigger, false);
            _animator.SetBool(AnimatorTriggers.DownTrigger, false);
            _animator.SetBool(AnimatorTriggers.UpTrigger, false);
        }
    }
}
