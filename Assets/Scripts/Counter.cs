using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI _label;
    [SerializeField] private float _intervalDuration = 0.5f;

    private int _count;
    private Coroutine _countRoutine;
    private WaitForSeconds _interval;

    private void Awake()
    {
        _count = 0;
        _interval = new WaitForSeconds(_intervalDuration);
    }

    private void Update()
    {
        ClickHandle();
    }

    private void ClickHandle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_countRoutine == null)
            {
                _countRoutine = StartCoroutine(Count());
            }
            else
            {
                StopCoroutine(_countRoutine);
                _countRoutine = null;
            }
        }
    }

    private IEnumerator Count()
    {
        while (enabled)
        {
            yield return _interval;

            _count++;
            UpdateLabel();
        }
    }

    private void UpdateLabel()
    {
        _label.text = _count.ToString();
    }
}
