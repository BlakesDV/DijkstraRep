using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Blakes.Graph
{
    [CustomEditor(typeof(Dijkstra))]
    public class Dijkstra_Editor : Editor
    {
        #region RuntimeVariables

        protected Dijkstra _dijkstra;

        #endregion

        #region UnityMethods

        public override void OnInspectorGUI()
        {
            if(_dijkstra == null)
            {
                _dijkstra = (Dijkstra)target;
            }
            DrawDefaultInspector();

            _dijkstra = (Dijkstra)target;
            if(GUILayout.Button("1) Probe nodes"))
            {
                _dijkstra.ProbeNodes();
            }
            if (GUILayout.Button("2) Create graph (by connecting the nodes)"))
            {
                
            }
            if (GUILayout.Button("3) Calculate distance"))
            {
                _dijkstra.CalculateDistances();
            }
            if (GUILayout.Button("4) Calculate all routes (and the best route to destiny)"))
            {
                _dijkstra.CalculateAllRoutes();
            }

       
            if (GUILayout.Button("Calculate all Dijkstra steps"))
            {
                _dijkstra.SetMovementOnScriptableObject();
            }
            if (GUILayout.Button("Clean all previous calculations"))
            {
                _dijkstra.CleanAllUp();
            }
        }

        #endregion
    }
}
