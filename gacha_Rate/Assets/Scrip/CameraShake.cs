using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private const float _COROUTINE_FREQUENCY = 0.05f;
    private Camera _mainCamera;
    private Vector3 _initCamPos;
    private bool _shaking;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !_shaking)
        // StartCoroutine(_ShakingCamera());
        if (!_shaking)
            StartCoroutine(_ShakingCamera());
    }
    public void call_ShakingCamera()
    {
        if (!_shaking)
            StartCoroutine(_ShakingCamera());
    }
    private IEnumerator _ShakingCamera(float magnitude = 0.25f)
    {
        _shaking = true;
        Debug.Log("shake");
        _initCamPos = _mainCamera.transform.position;
        float t = 0f, x, y;
        while (t < 0.35f)
        {
            x = Random.Range(-10f, 10f) * magnitude;
            y = Random.Range(-10f, 10f) * magnitude;

            _mainCamera.transform.position = new Vector3(x, y, _initCamPos.z);

            t += _COROUTINE_FREQUENCY;
            yield return new WaitForSeconds(_COROUTINE_FREQUENCY);
        }

        _mainCamera.transform.position = _initCamPos;
        _shaking = false;
    }
}