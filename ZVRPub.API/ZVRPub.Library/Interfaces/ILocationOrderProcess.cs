using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Scaffold;

namespace ZVRPub.Library.Interfaces
{
    interface ILocationOrderProcess
    {
         int Id { get; set; }
         int LocationId { get; set; }
         int OrderId { get; set; }

         Locations Location { get; set; }
         Orders Order { get; set; }


    }
}
