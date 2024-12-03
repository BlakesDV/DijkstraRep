using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Blakes.Graph
{
    [System.Serializable]
    public class Connection
    {
        #region References

        //Always two nodes
        [SerializeField] public Node nodeA;
        [SerializeField] public Node nodeB;
        [SerializeField] public float distanceBetweenNodes;

        #endregion

        #region Public Methods

        public Node RetreiveOtherNodeThan(Node value)
        {
            if (value == nodeA)
            {
                return nodeB;
            }
            else //if (value == nodeB)
            {
                return nodeA;
            }
        }

        #endregion
    }

    [System.Serializable]
    public class Route
    {
        #region Variables

        [SerializeField] public List<Node> nodes;
        [SerializeField] public float sumDistance;

        #endregion

        #region Constructors

        //Generate a constructor to generate a new pointer of this new Route
        public Route()
        {
            nodes = new List<Node>();
            sumDistance = 0;
        }

        public Route(List<Node> nodesToClone, float sumDistanceToCopy)
        {
            //Generates a new pointer in the RAM for this NEW collection of nodes
            nodes = new List<Node>();
            foreach (Node node in nodesToClone)
            {
                nodes.Add(node);
            }
            //*nodes != *nodesToClone
            //Each node reference is the same between both lists

            //For primitive variables the asignation is a copy/clone process of the values, but not for classes
            sumDistance = sumDistanceToCopy;
        }


        #endregion

        #region PublicMethods

        public void AddNode(Node nodeValue, float sumValue)
        {
            nodes.Add(nodeValue);
            sumDistance += sumValue;
        }

        public bool ContainsNodeInRoute(Node value)
        {
            foreach (Node node in nodes)
            {
                if (value == node)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}