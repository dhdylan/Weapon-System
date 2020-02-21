using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testBlocks : MonoBehaviour
{
    private TextMeshPro textMeshProScript;
    private CharacterStats cubeCharacterStats;

    void Start()
    {
        cubeCharacterStats = GetComponent<CharacterStats>();
        cubeCharacterStats.CurrentHealth = 101;
        textMeshProScript = GetComponentInChildren<TextMeshPro>();
        textMeshProScript.text = cubeCharacterStats.CurrentHealth.ToString();
    }

    void Update()
    {
        textMeshProScript.text = cubeCharacterStats.CurrentHealth.ToString();
    }
}
