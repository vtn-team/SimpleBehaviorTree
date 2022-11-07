using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class Attack : IBehavior
    {
        [SerializeField] float _time;

        float _timer = 0.0f;

        public Result Action(Environment env)
        {
            if (env.Visit(this))
            {
                _timer = 0.0f;
            }

            _timer += Time.deltaTime;
            if (_timer < _time) return Result.Running;

            Debug.Log("攻撃した");

            env.Leave(this);
            return Result.Success;
        }
    }
}
