using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Blakes.Graph
{
    public class Node : MonoBehaviour
    {
        #region References

        //0 to any connections
        [SerializeField] protected List<Connection> connections;

        #endregion

        #region UnityMethods

        private void OnDrawGizmos()
        {
            foreach (Connection connection in connections)
            {
                Debug.DrawLine(
                    connection.nodeA.transform.position,
                    connection.nodeB.transform.position,
                    Color.magenta,
                    0.016666666f
                    );
            }
        }

        #endregion
    }
}