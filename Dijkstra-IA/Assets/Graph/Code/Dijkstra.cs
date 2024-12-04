using Blakes.FiniteStateMachine.Agents;
using Blakes.FiniteStateMachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Blakes.Dijkstra;
using UnityEngine.UIElements;

namespace Blakes.Graph
{
    public class Dijkstra : MonoBehaviour
    {
        #region References
        [SerializeField] EnemyInteractiveScript_ScriptableObject enemyInteractiveScript;
        //Both will be obtained by calculating the lesser distance between Avatar vs all nodes and Goal vs all nodes
        [SerializeField] public Node initialNode;
        [SerializeField] public Node finalNode;
        //The collection of all the nodes which every node containts multiple connections defines the graph
        [SerializeField] protected List<Node> graph;
        [SerializeField] protected GameObject nodePrefab;

        #endregion

        #region Runtime Variables

        protected Route initialRoute;
        [SerializeField] protected int width;
        [SerializeField] protected int height;
        [SerializeField] protected int spacing;
        [SerializeField] protected List<Route> allRoutes;
        [SerializeField] protected List<Route> succesfulRoutes;
        [SerializeField] protected List<Route> ogRoute;
        //Succesful routes, truncated routes and faliled routes

        #endregion

        #region GUILayoutButton

        public void ProbeNodes()
        {
            //2  for (x,y)
            //instance go
            //go call function of the RaycastNode
            //foreach (Node node in graph)
            //{
            //    node.SumDistance();
            //}
            int numeroDeNodo = 1;

            for (int x = 0; x < height; x++)
            {
                for (int z = 0; z < width; z++)
                {
                    Vector3 spawnPosition = new Vector3(x * spacing, 0, z * spacing);

                    GameObject nodeToPlace = Instantiate(nodePrefab, spawnPosition, Quaternion.identity);
                    nodeToPlace.transform.parent = transform;
                    graph.Add(nodeToPlace.GetComponent<Node>());
                    nodeToPlace.GetComponent<RaycastNode>().RaycastToNode();
                    nodeToPlace.gameObject.name = "Nodo " + numeroDeNodo;
                    numeroDeNodo++;
                }
            }
        }

        public void CreateGraph()
        {
            foreach (Node actualNode in graph)
            {
                RaycastHit raycastHit;
                foreach (Node nextNode in graph)
                {
                    if (actualNode == nextNode)
                    {
                        Debug.Log("Same Node " + actualNode.name);
                    }
                    else
                    {
                        if (Physics.Raycast(actualNode.transform.position, actualNode.transform.position - nextNode.transform.position, out raycastHit, 20f))
                        {
                            if (raycastHit.transform.gameObject.CompareTag("Node"))
                            {
                                Connection graphNodes = new Connection();
                                graphNodes.nodeA = actualNode; //blakes
                                graphNodes.nodeB = nextNode; //charlie
                                graphNodes.distanceBetweenNodes = Vector3.Distance(graphNodes.nodeA.transform.position, graphNodes.nodeB.transform.position);
                                actualNode.AddConnection(graphNodes);
                                //connections.Add(ActualListOfNodes);
                            }
                        }
                    }
                }
            }
        }

        public void CalculateAllRoutes()
        {
            initialRoute = new Route();
            initialRoute.AddNode(initialNode, 0);
            allRoutes = new List<Route>();
            allRoutes.Add(initialRoute);

            //Recursive method
            ExploreBranchTree(initialRoute, initialNode);
            SuccesfulRoutes();
            OgRoute();
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
                //Validate the connections on the actual node
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
                }
                //Break point of the method
            }
        }

        public void CalculateDistances()
        {
            foreach(Node node in graph)
            {
                node.SumDistance();
            }
        }

        //public void CalculateRouteSums()
        //{
        //    foreach (Route route in succesfulRoutes)
        //    {
        //        route.nodes
        //    }
        //}
        public void SuccesfulRoutes()
        {

            foreach (Route routes in allRoutes) 
            {
                if (routes.ContainsNodeInRoute(finalNode)) 
                {
                    succesfulRoutes.Add(routes);
                }
            }
        }
        public void OgRoute()
        {
            Route newRoute = new Route();
            float OgRouteSum = 1000;

            foreach (Route route in succesfulRoutes)
            {

                if (route.sumDistance < OgRouteSum)
                {
                    OgRouteSum = route.sumDistance;
                    newRoute = route;
                    ogRoute.Add(newRoute);
                }
            }
        }


        public void CleanAllUp()
        {
            foreach (Node node in graph)
            {
                DestroyImmediate(node.gameObject);
            }
            graph.Clear();
            allRoutes.Clear();
            succesfulRoutes.Clear();
            ogRoute.Clear();
            enemyInteractiveScript.patrolScript.Clear();
        }

        public void SetMovementOnScriptableObject()
        {
            Route selectedRoute = ogRoute[0];
            foreach (Node node in selectedRoute.nodes)
            {
                PatrolScript _patrolScript = new PatrolScript();
                _patrolScript.actionToExecute = Actions.WALK;
                _patrolScript.speedOrTime = 5f;
                _patrolScript.destinyVector = node.transform.position;
                enemyInteractiveScript.patrolScript.Add(_patrolScript);
            }
        }

        #endregion
    }
}