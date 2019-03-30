using System;
using System.Collections.Generic;
using System.Text;

namespace BFI.Domain
{
    public class IEntity<T>
    {
        T Id { get; }
    }
}
