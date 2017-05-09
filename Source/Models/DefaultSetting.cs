using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models
{
    public static class DefaultSetting
    {
        /// <summary>
        /// Indicator for Setting Container of application's first time operation.
        /// The container stores 1 if it is launched first time.
        /// </summary>
        public static readonly string  IsFirstTimeLaunched = "IsFirstTimeLaunched";
    }
}
