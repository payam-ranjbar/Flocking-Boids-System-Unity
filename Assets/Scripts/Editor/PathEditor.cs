using System.Collections.Generic;
using Navigation;
using UnityEngine;
using UnityEditor;

namespace CarEditor
{
    [CustomEditor(typeof(Path))]
    public class CarEngineEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("reverse"))
            {
                    
                ReverseNodes();
            }
            
                
                
        }
        

        public void ReverseNodes()
        {
            var t = target as Path;
            var index = 0;
            for (int i = t.NodeCount - 1; i >= 0; i--)
            {
                t.Waypoints[i].transform.SetSiblingIndex(index++);
            }
        }

       
    }


}
  