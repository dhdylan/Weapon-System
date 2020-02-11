//C# Example (LookAtPointEditor.cs)
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateWeapon))]
[CanEditMultipleObjects]
public class CreateWeaponEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CreateWeapon createWeaponScript = (CreateWeapon)target;

        if (GUILayout.Button("Set Weapon"))
        {
            createWeaponScript.SetWeapon();
            Debug.Log("poop");
        }
    }
}