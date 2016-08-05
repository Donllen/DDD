using System.Windows;
using System.Windows.Media;

namespace Microsoft.Research.DynamicDataDisplay.PointMarkers
{
    /// <summary>Renders circle around each point of graph</summary>
    /// 
    ///TODO. 画一个文本提示
	public class CirclePointMarker : ShapePointMarker {

        public override void Render(DrawingContext dc, Point screenPoint) {
			dc.DrawEllipse(Fill, Pen, screenPoint, Size / 2, Size / 2);
            
            dc.DrawText(new FormattedText("M1",//s
                System.Globalization.CultureInfo.GetCultureInfo("zh-cn"),
                FlowDirection.LeftToRight,
                  new Typeface("Verdana"),
                  8,
                  Brushes.Black) , screenPoint);
		}
        public override void Render(DrawingContext dx, Point screenPoint, MarkersPoint mp)
        {
            dx.DrawEllipse(Fill, Pen, screenPoint, Size / 2, Size / 2);

            dx.DrawText(new FormattedText(mp.desc,//s
                System.Globalization.CultureInfo.GetCultureInfo("zh-cn"),
                FlowDirection.LeftToRight,
                  new Typeface("Verdana"),
                  8,
                  Brushes.Black), screenPoint);
        }
	}

}
