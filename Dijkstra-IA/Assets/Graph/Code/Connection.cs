using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blakes.Graph
{
    public class Connection : MonoBehaviour
    {
        //Always two nodes
        [SerializeField] protected Node nodeA;
        [SerializeField] protected Node nodeB;
    }
}