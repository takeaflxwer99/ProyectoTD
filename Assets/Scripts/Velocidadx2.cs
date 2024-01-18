using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

    public class Velocidadx2 : MonoBehaviour
    {

        private Button _speedBtn;
        private bool _isPressed;
        private float _gameSpeed;

        private void Awake()
        {
            _isPressed = false;
            _gameSpeed = 1f;
            Time.timeScale = _gameSpeed;
            _speedBtn = GetComponent<Button>();
            _speedBtn.onClick.AddListener(OnSpeedBtnClick);
        }

        private void Start()
        {
        UpdateTimeScale();

        }

    private void UpdateTimeScale()
    {
        Time.timeScale = _isPressed ? 2f : 1f;
    }
    private void OnSpeedBtnClick()
        {
        _isPressed = !_isPressed;
        UpdateTimeScale();

        }
    }
