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
        [SerializeField] protected int nodesFound;

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

        #region PublicMethods

        public void SumDistance()
        {
            foreach (Connection connection in connections) {
                connection.distanceBetweenNodes = Vector3.Distance(connection.nodeA.transform.position, connection.nodeB.transform.position);

            }
            //TODO: Obtener la distancia entre nodos???
            //Connection connection = new Connection ();
            //connections[nodesFound].distanceBetweenNodes = Vector3.Distance(gameObject.transform.position , connection.nodeB.transform.position);
        }

        #endregion

        #region Getters

        public List<Connection> GetConnections 
        {
            get { return connections; }
        }

        #endregion
    }
}