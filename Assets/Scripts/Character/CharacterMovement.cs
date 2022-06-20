using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterAnimation _animation;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Joystick _joystick;

    public float Speed { get; private set; }

    private bool _moveAllowed;

    private void OnEnable()
    {
        _animation.OnFinishCutEvent += MoveAllowed;
    }

    private void OnDisable()
    {
        _animation.OnFinishCutEvent -= MoveAllowed;
    }

    private void Start()
    {
        _moveAllowed = true;
    }

    private void Update()
    {
        if (_moveAllowed == true)
        {
            Speed = Mathf.Abs(_joystick.Horizontal) + Mathf.Abs(_joystick.Vertical);

            _animation.Movement(Speed);

            if (_joystick.Direction != Vector2.zero)
            {
                Vector3 direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
                _playerTransform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    private void MoveAllowed()
    {
        _moveAllowed = true;
    }
}
