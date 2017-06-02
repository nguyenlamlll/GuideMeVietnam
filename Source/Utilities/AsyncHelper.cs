using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Utilities
{
    /// <summary>
    /// Store extension methods to help with async tasks.
    /// </summary>
    public static class AsyncHelper
    {
        public static async Task ForEachAsync<T>(this List<T> list, Func<T, Task> func)
        {
            foreach (var value in list)
            {
                await func(value);
            }
        }

    }
}
