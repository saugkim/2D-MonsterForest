using UnityEngine;
using UnityEditor;
using System.Collections;

public class SelectionInfo
{
    [MenuItem("Tools/Selection Info", false, 10)]
    public static void ShowInfo()
    {
        Debug.Log(Selection.objects.Length + " objects selected");
    }

    [MenuItem("Tools/Selection Info", true)]
    public static bool ShowInfoValidator()
    {
        return Selection.objects.Length > 0;
    }

    [MenuItem("Tools/Clear selection", false, 20)]
    public static void ClearSelection()
    {
        Selection.activeObject = null;
    }
}