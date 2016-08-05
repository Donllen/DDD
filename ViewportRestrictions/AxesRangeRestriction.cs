using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Research.DynamicDataDisplay.ViewportRestrictions
{
    /// <summary>
    /// 设定显示范围
    /// </summary>
    public class DisplayRange
    {
        public double Start { get; set; }
        public double End { get; set; }
        public DisplayRange(double start, double end)
        {
            Start = start;
            End = end;
        }
    }
    public class ViewportAxesRangeRestriction : ViewportRestriction
    {

        public DisplayRange XRange = null;
        public DisplayRange YRange = null;
        public override DataRect Apply(DataRect oldVisible, DataRect newVisible, Viewport2D viewport)
        {
            if (XRange != null)
            {
                newVisible.XMin = XRange.Start;
                newVisible.Width = XRange.End - XRange.Start;
            }
            if (YRange != null)
            {
                newVisible.YMin = YRange.Start;
                newVisible.Height = YRange.End - YRange.Start;
            }
            return newVisible;
        }
       // public event EventHandler Changed;
    }
}
