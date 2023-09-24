using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Slider _forceSlider;
    [SerializeField] Slider _torqueForceSlider;
    [SerializeField] Text _shootDirectionX;
    [SerializeField] Text _shootDirectionY;
    [SerializeField] Text _shootDirectionZ;
    [Header("Ball")]
    [SerializeField] Ball _ball;
    [SerializeField] Vector3 _leftPosition;
    [SerializeField] Vector3 _centerPosition;
    [SerializeField] Vector3 _rightPosition;
    [SerializeField] Transform _ballDirectionCubeTranform;
    [Header("Camera")]
    [SerializeField] Camera _camera;
    [SerializeField] Vector3 _leftCameraPosition;
    [SerializeField] Vector3 _centerCameraPosition;
    [SerializeField] Vector3 _rightCameraPosition;
    [SerializeField] Quaternion _leftCameraRotation;
    [SerializeField] Quaternion _centerCameraRotation;
    [SerializeField] Quaternion _rightCameraRotation;

    private void Start()
    {
        _shootDirectionX.text = "0";
        _shootDirectionY.text = "1";
        _shootDirectionZ.text = "5";
    }
    private void Update()
    {
        SetShootDirectionCube();
    }
    public void UpdateForce()
    {
        float offsetForce = 20f;
        float forceRange = 60f;
        _ball.Force = forceRange * _forceSlider.value + offsetForce;
    }
    public void UpdateTorqueForce()
    {
        float torqueForceRange = 0.5f;
        _ball.TorqueForce = torqueForceRange * _torqueForceSlider.value;
    }
    public void SetLeftPosition()
    {
        _ball.transform.position = _leftPosition;
        _ball.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        _camera.transform.position = _leftCameraPosition;
        _camera.transform.rotation = _leftCameraRotation;
        _ball.ResetPosition = _leftPosition;
    }
    public void SetCenterPosition()
    {
        _ball.transform.position = _centerPosition;
        _ball.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        _camera.transform.position = _centerCameraPosition;
        _camera.transform.rotation = _centerCameraRotation;
        _ball.ResetPosition = _centerPosition;
    }
    public void SetRightPosition()
    {
        _ball.transform.position = _rightPosition;
        _ball.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        _camera.transform.position = _rightCameraPosition;
        _camera.transform.rotation = _rightCameraRotation;
        _ball.ResetPosition = _rightPosition;
    }

    public void SetSpinLeftTop()
    {
        _ball.TorqueDirection = new Vector3(1f, 1f, 0.0f);
    }
    public void SetSpinTop()
    {
        _ball.TorqueDirection = new Vector3(1f, 0.0f, 0.0f);
    }
    public void SetSpinRightTop()
    {
        _ball.TorqueDirection = new Vector3(1f, -1f, 0.0f);
    }
    public void SetSpinLeft()
    {
        _ball.TorqueDirection = new Vector3(0.0f, -1f, 0.0f);
    }
    public void SetSpinRight()
    {
        _ball.TorqueDirection = new Vector3(0.0f, 1f, 0.0f);
    }
    public void SetSpinLeftBottom()
    {
        _ball.TorqueDirection = new Vector3(-1f, 1f, 0.0f);
    }
    public void SetSpinBottom()
    {
        _ball.TorqueDirection = new Vector3(-1f, 0.0f, 0.0f);
    }
    public void SetSpinRightBottom()
    {
        _ball.TorqueDirection = new Vector3(-1f, -1f, 0.0f);
    }
    public void SetShootDirectionX()
    {
        _ball.Direction.x = float.Parse(_shootDirectionX.text);
        SetShootDirectionCube();
    }
    public void SetShootDirectionY()
    {
        _ball.Direction.y = float.Parse(_shootDirectionY.text);
        SetShootDirectionCube();
    }
    public void SetShootDirectionZ()
    {
        _ball.Direction.z = float.Parse(_shootDirectionZ.text);
        SetShootDirectionCube();
    }
    public void SetShootDirectionCube()
    {
        _ballDirectionCubeTranform.rotation = Quaternion.LookRotation(_ball.Direction);
    }
}
