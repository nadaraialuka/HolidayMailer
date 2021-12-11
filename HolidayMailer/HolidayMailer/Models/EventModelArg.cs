using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMailer.Models
{
    internal class EventModelArg: EventArgs
    {
        public string TargetEmail { get; set; }
        public string TargetName { get; set; }
        public string Name { get; set; }
    }
}
