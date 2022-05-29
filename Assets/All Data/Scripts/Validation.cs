using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Validation : MonoBehaviour
{
    public TMP_InputField field;

    public UnityEvent onValid, onInvalid;


    public void Validate()
    {
        if(string.IsNullOrEmpty(field.text))
        {
            onInvalid.Invoke();
        }
        else
        {
            onValid.Invoke();
        }
    }
}
