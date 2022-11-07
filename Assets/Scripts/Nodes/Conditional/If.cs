using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class TooFar : IBehavior
    {
        [SerializeField] float length;
        [SerializeField, SerializeReference, SubclassSelector] IBehavior Next;

        public Result Action(Environment env)
        {
            //if(Func.Judge(env))
            if((env.target.transform.position - env.mySelf.transform.position).sqrMagnitude > length)
            {
                return Next.Action(env);
            }
            else
            {
                return Result.Failure;
            }
        }
    }
}
