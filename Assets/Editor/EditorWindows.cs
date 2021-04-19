using UnityEditor;

namespace Editor
{
    public class EditorWindows
    {
        [MenuItem("My windows/Prefabs Settings")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyEditorWindow), false, "Prefabs Settings");
        }
    }
}