using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class PrioritySelector : IBehavior
    {
        [Serializable]
        public class SelectorChildPriority
        {
            public bool Visit;
            public int Priority;
            [SerializeReference, SubclassSelector] public IBehavior Node;
        }

        [SerializeField] List<SelectorChildPriority> ChildNodes;
        IBehavior _current = null;

        public Result Action(Environment env)
        {
            if(env.Visit(this))
            {
                _current = null;
                ChildNodes.ForEach(n => n.Visit = false);
            }

            do
            {
                if (_current != null)
                {
                    Result ret = _current.Action(env);
                    if (ret == Result.Running) return Result.Running;
                    _current = null;
                    return ret;
                }

                var nodes = ChildNodes.OrderByDescending(n => n.Priority);
                foreach (var node in nodes)
                {
                    if (node.Visit) continue;
                    _current = node.Node;
                    break;
                }
            } while (_current != null);

            env.Leave(this);
            return Result.Success;
        }
    }

    [Serializable]
    public class RandomSelector : IBehavior
    {
        /*
        [Serializable]
        public class SelectorChildRandom
        {
            public int Weight;
            [SerializeReference, SubclassSelector] public IBehavior Node;
        }
        */
        [SerializeField, SerializeReference, SubclassSelector] List<IBehavior> ChildNodes;
        IBehavior _current = null;

        public Result Action(Environment env)
        {
            if (env.Visit(this))
            {
                _current = null;
            }

            do
            {
                if (_current != null)
                {
                    Result ret = _current.Action(env);
                    if (ret == Result.Running) return Result.Running;
                    _current = null;
                    return ret;
                }

                _current = ChildNodes.OrderBy(n => Guid.NewGuid()).FirstOrDefault();
            } while (_current != null);

            env.Leave(this);
            return Result.Success;
        }
    }
}