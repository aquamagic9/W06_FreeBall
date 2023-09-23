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
    [SerializeField] float Cd = 0.25f;
    [SerializeField] float Cl = 0.25f;
    [SerializeField] float Spin;


    float _drag;
    float _lift;
    float _radius;
    float _crossSectionalArea;
    Vector3 _liftVec;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _radius = GetComponent<SphereCollider>().bounds.size.x / 2f;
        _radius *= 0.1f;
        _crossSectionalArea = _radius * _radius * Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        DebugFunc();
        ResetPosition();
    }
    private void FixedUpdate()
    {
        CalculateForce();
    }
    public void ShootBall()
    {
        _rigidbody.AddForce(Direction.normalized * Force, ForceMode.Impulse);
    }
    private void CalculateForce()
    {
        _drag = 0.5f * Rho * _rigidbody.velocity.magnitude * _rigidbody.velocity.magnitude * _crossSectionalArea * Cd;
        //_lift = Cl * 4f / 3f * (4f * Mathf.PI * Mathf.PI * Rho * _rigidbody.angularVelocity.magnitude * _radius * _radius * _radius);
        _lift = 0.5f * Rho * Cl * _rigidbody.velocity.magnitude * _rigidbody.velocity.magnitude * _crossSectionalArea * _rigidbody.angularVelocity.magnitude;
        _lift *= 0.1f;
        _rigidbody.drag = _drag;
        _liftVec = Vector3.Cross(_rigidbody.angularVelocity.normalized, _rigidbody.velocity.normalized);
        _rigidbody.AddForce(_liftVec.normalized * _lift, ForceMode.Impulse);
    }
    private void DebugFunc()
    {
        Debug.Log("Drag: " + _drag + "Lift: " + _lift);
        Debug.DrawRay(this.transform.position, _rigidbody.velocity.normalized * 10f, Color.red);
        Debug.DrawRay(this.transform.position, _liftVec.normalized * 10f, Color.blue);
    }

    private void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.transform.position = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;        
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 force = new Vector3(0, 0, 1);
            Vector3 torque = Vector3.Cross(Vector3.right, force);
            _rigidbody.AddTorque(TorqueDirection.normalized * TorqueForce, ForceMode.Impulse);
        }
    }
}
