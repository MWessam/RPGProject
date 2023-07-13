using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerMovementComponent : MovementComponent
{
    float _x;
    float _y;
    Rigidbody _rigidbody;
    [SerializeField] float _speed;
    public static UnityEvent onMove;
    [SerializeField, Range(0, 0.1f)] private float _amplitude = 0.015f;
    [SerializeField, Range(0, 30f)] private float _frequency = 10.0f;
    [SerializeField] Image _weaponSprite;
    [SerializeField] Transform _cameraHolder;
    public override float Speed { get => _speed; set => _speed = value <= 10 && value >= 0 ? value : 5; }
    Camera _camera;
    Vector3 _startPosCamera;
    Vector3 _startPosWeapon;
    Vector3 _inputs;
    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _startPosCamera = _camera.transform.localPosition;
        _startPosWeapon = _weaponSprite.rectTransform.position;
    }
    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude / 2;
        return pos;
    }
    private void ResetPosition()
    {
        _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, _startPosCamera, Time.deltaTime);
        _weaponSprite.rectTransform.position = Vector3.Lerp(_weaponSprite.rectTransform.position, _startPosWeapon, Time.deltaTime);
    }
    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }
    private void PlayMotion(Vector3 motion)
    {
        _camera.transform.localPosition += motion;
        _weaponSprite.rectTransform.position += motion * 10;
    }
    private void CheckMotion()
    {
        if (_x == 0 && _y == 0)
        {
            ResetPosition();
            return;
        }
        PlayMotion(FootStepMotion());
    }
    private void Update()
    {
        _inputs = HandleUserInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        CheckMotion();
        //_camera.transform.LookAt(FocusTarget());
    }
    public override void Move()
    {
        _rigidbody.AddForce(_inputs * _speed, ForceMode.Acceleration);
    }
    private Vector3 HandleUserInput()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        return transform.right * _x + transform.forward * _y;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 directionVector = collision.transform.position - transform.position;
        //transform.position -= 0.1f * directionVector;
    }
}
