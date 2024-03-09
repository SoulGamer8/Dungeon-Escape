using UnityEditor;
using UnityEngine;
using NeverMindEver.Enemy;

#if UNITY_EDITOR
[CustomEditor(typeof(Enemy))]
public class ObjectBuilderEditor : Editor
{ 
    public override void OnInspectorGUI()
    {
       
    }
}
#endif