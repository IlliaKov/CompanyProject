using System.Collections.Generic;

namespace M.Interface
{
    public interface IStrategy
    {
        List<Interface.IEmployee> Subordinate();
    }
}
