using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private int _currentValue;
    private int _maxValue;

    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetValues(int currentValue, int maxValue)
    {
        _currentValue = currentValue;
        _maxValue = maxValue;

        _text.text = _currentValue.ToString();

        CalculateFillAmount();
    }

    private void CalculateFillAmount()
    {
        float fillAmount = (float)_currentValue / (float)_maxValue;
        _fill.fillAmount = fillAmount;
    }
}
