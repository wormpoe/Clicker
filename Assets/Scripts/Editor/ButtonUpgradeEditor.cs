using UnityEditor;

[CustomEditor(typeof(ButtonUpgrade))]
public class ButtonUpgradeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ButtonUpgrade buttonUpgrade = (ButtonUpgrade)target;
        serializedObject.Update();
        base.OnInspectorGUI();
        if (buttonUpgrade.TypeName == TypeName.DpsPower)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_dpsUpgradeName"));
        }
        serializedObject.ApplyModifiedProperties();
    }
}
