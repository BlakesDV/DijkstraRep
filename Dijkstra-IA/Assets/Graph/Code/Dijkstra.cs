using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Blakes.Graph
{
    public class Dijkstra : MonoBehaviour
    {
        #region References

        //Both will be obtained by calculating the lesser distance between Avatar vs all nodes and Goal vs all nodes
        [SerializeField] public Node initialNode;
        [SerializeField] public Node finalNode;
        //The collection of all the nodes which every node containts multiple connections defines the graph
        [SerializeField] protected List<Node> graph;

        #endregion

        #region Runtime Variables

        protected Route initialRoute;
        protected List<Route> allRoutes;
        //Succesful routes, truncated routes and faliled routes

        #endregion

        #region GUILayoutButton

        public void ProbeNodes()
        {
            //2  for (x,y)

            //instance go
            //go call function of the RaycastNode
        }

        public void CalculateAllRoutes()
        {
            initialRoute = new Route();
            initialRoute.AddNode(initialNode, 0);
            allRoutes = new List<Route>();
            allRoutes.Add(initialRoute);

            //Recursive method
            ExploreBranchTree(initialRoute, initialNode);
        }

        #endregion

        #region Local Methods

        //Recursive method
        protected void ExploreBranchTree(Route previousRoute, Node actualNodeToExplore)
        {
            //Are we in the destiny node
            //Break point for recusivity
            if (actualNodeToExplore == finalNode)
            {
                //Break point for recursivity for this level
                return;
            }
            else
            {
                //Validate the connections oh the actual node
                foreach (Connection connectionOfTheActualNode in actualNodeToExplore.GetConnections)
                {

                    Node nextNode = connectionOfTheActualNode.RetreiveOtherNodeThan(actualNodeToExplore);

                    if (!previousRoute.ContainsNodeInRoute(nextNode))
                    {
                        //1) Connection to a previously explored node in the route
                        //Break point for recursivity

                        Route newRoute = new Route(previousRoute.nodes, previousRoute.sumDistance);
                        newRoute.AddNode(nextNode, connectionOfTheActualNode.distanceBetweenNodes);
                        allRoutes.Add(newRoute); //Truncated route
                                                 //Invocation to itself
                        ExploreBranchTree(newRoute, nextNode);
                    }
                    else
                    {
                        //2) Further exploration in a branch of the tree
                        //Invocation to itself
                    }
                }
                //Break point of the method
            }
        }
        #endregion
    }
}