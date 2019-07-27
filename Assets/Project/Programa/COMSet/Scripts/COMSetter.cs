using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Windows決め打ちハードコーディング
/// Mac対応するならCOMを変える
/// </summary>
public class COMSetter : MonoBehaviour {

    UnityEngine.UI.Text _text;
    public UnityEngine.UI.Text _sub_text;
    int _comNumber = 1;
	private void Start () {
        _text = GetComponent<UnityEngine.UI.Text>();
        if (GrobalData.LEDComNumber != -1)
        {
            _text.text = "COM" + GrobalData.LEDComNumber;
            _comNumber= GrobalData.LEDComNumber;
        }
        else
        {
            _comNumber = 0;
        }
    }
	
	private void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ComNumberPlus();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            ComNumberMinus();

        if (_comNumber > 20)
            _comNumber = 1;
        if (_comNumber < 1)
            _comNumber = 20;
        _text.text = "COM" + _comNumber;
        _sub_text.text = "COM" + _comNumber;
        GrobalData.LEDComNumber = _comNumber;
	}

    public void ComNumberPlus()
    {
        _comNumber++;
    }

    public void ComNumberMinus()
    {
        _comNumber--;
    }

    public void SetCOM()
    {
        PlayerPrefs.SetInt("COM", _comNumber);
    }
}
