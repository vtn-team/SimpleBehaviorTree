using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
    public enum Result
    {
        Running,
        Success,
        Failure
    }

    public interface IBehavior
    {
        Result Action(Environment env);
    }
}
