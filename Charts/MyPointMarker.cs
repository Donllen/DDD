using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Research.DynamicDataDisplay
{
    public class MyPointMarker
    {
        public float x { get; set; }
        public string desc { get; set; }
        public bool isdis { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(MyPointMarker)) return false;
            MyPointMarker C = obj as MyPointMarker;
            return (this.x == C.x);
        }
    }
}
