using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class Sequence : IBehavior
    {
        [SerializeField, SerializeReference, SubclassSelector] List<IBehavior> ChildNodes;

        int index = 0;

        public Result Action(Environment env)
        {
            if(env.Visit(this))
            {
                index = 0;
            }

            if (index >= ChildNodes.Count)
            {
                env.Leave(this);
                return Result.Success;
            }

            Result ret = ChildNodes[index].Action(env);
            if (ret == Result.Running) return Result.Running;

            index++;
            return ret;
        }
    }
}