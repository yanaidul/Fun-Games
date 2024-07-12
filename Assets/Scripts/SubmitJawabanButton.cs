using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SubmitJawabanButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputFieldJawaban;
    [SerializeField] private string _jawaban;
    [SerializeField] private Soal _soal;

    //Function yang dipanggil pada saat gameobject dinyalakan
    private void OnEnable()
    {
        _inputFieldJawaban.text = string.Empty;
    }

    //Function yang dipanggil pada saat gameobject dinyalakan
    void Start()
    {
        _inputFieldJawaban.onValidateInput += delegate (string s, int i, char c) { return char.ToUpper(c); };
    }

    //Function yang dipanggil pada saat submit button di klik untuk melakukan pengecekan jawaban
    public void OnSubmitJawaban()
    {
        if(_inputFieldJawaban.text == _jawaban)
        {
            Debug.Log("Jawaban benar");
            _soal.OnSubmitJawabanBenar();
        }
        else
        {
            Debug.Log("Jawaban salah");
            _soal.OnSubmitJawabanSalah();
            _inputFieldJawaban.transform.DOShakePosition(0.5F,20,10,90);
        }
    }
}
