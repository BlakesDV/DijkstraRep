using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blakes.Graph
{
    public class Dijkstra : MonoBehaviour
    {
        //The collection of all the nodes which every node containts multiple connections defines the graph
        [SerializeField] protected List<Node> graph;
    }
}