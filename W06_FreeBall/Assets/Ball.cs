using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] Vector3 Direction;
    [SerializeField] Vector3 TorqueDirection;
    [SerializeField] float Force;
    [SerializeField] float TorqueForce;
    [SerializeField] float Rho;
    [SerializeField] float CrossSectionalArea;
    [SerializeField] float Cd = 0.25f;
    [SerializeField] float Cl = 0.25f;
    [SerializeField] float Spin;


    float _drag;
    float _lift;
    float _radius;
   void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _radius = GetComponent<SphereCollider>().bounds.size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateForce();
        DebugFunc();
    }
    public void ShootBall()
    {
        _rigidbody.AddForce(Direction * Force);
    }
    public void CalculateForce()
    {
        _drag = 0.5f * Rho * _rigidbody.velocity.sqrMagnitude * _rigidbody.velocity.sqrMagnitude * CrossSectionalArea * Cd;
        _lift = Cl * 4f / 3f * (4f * Mathf.PI * Mathf.PI * Rho * Spin * _radius);
    }
    private void DebugFunc()
    {
        Debug.Log("Drag: " + _drag + "Lift: " + _lift);
    }
}
