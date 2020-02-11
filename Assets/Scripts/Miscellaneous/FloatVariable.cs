using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Float Variable", order = 51)]
public class FloatVariable : ScriptableObject,
ISerializationCallbackReceiver
{
    [SerializeField]
    private float InitialValue;
    private float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {

    }

    public float runtimeValue
    {
        get
        {
            return RuntimeValue;
        }

        set
        {
            RuntimeValue = value;
        }
    }

    public float initialValue
    {
        get
        {
            return InitialValue;
        }

        set
        {
            InitialValue = value;
        }
    }
}
