using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BehaviorTree
{
    public class Environment
    {
        //共有変数の定義
        public GameObject mySelf;
        public GameObject target;

        List<IBehavior> visit = new List<IBehavior>();
        public bool Visit(IBehavior node)
        {
            if(visit.Where(n => n == node).Count() == 0)
            {
                visit.Add(node);
                return true;
            }
            return false;
        }
        public void Leave(IBehavior node)
        {
            var n = visit.Where(n => n == node);
            if (n.Count() == 0) return;

            visit.Remove(n.Single());
        }
    }
}
