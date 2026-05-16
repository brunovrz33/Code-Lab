using System;
using System.Collections.Generic;
using System.Text;

namespace ex31.Services
{
    using System;
    using System.Collections.Generic;

    namespace ex31.Services
    {
        class CalculationService
        {
            public T Max<T>(List<T> list) where T : IComparable<T>
            {
                if (list == null || list.Count == 0)
                    throw new InvalidOperationException("List is empty.");

                T max = list[0];
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].CompareTo(max) > 0)
                        max = list[i];
                }
                return max;
            }
        }
    }
}
