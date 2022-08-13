#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Assets.SimpleLocalization.Editor
{
	/// <summary>
	/// Adds "Sync" button to LocalizationSync script.
	/// </summary>
    #if UNITY_EDITOR
	[CustomEditor(typeof(LocalizationSync))]
    public class LocalizationSyncEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var component = (LocalizationSync) target;

            if (GUILayout.Button("Sync"))
            {
	            component.Sync();
            }
		}
    }
    #endif
}