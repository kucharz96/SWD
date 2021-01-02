using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD
{
    public class DecisionTreeNode
    {

        public string Attribute;
        public bool IsDecision;
        public Dictionary<string, DecisionTreeNode> LinkedNodes = new Dictionary<string, DecisionTreeNode>();
    }
}
