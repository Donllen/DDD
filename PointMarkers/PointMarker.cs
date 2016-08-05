using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Microsoft.Research.DynamicDataDisplay.PointMarkers
{
	public delegate void MarkerRenderHandler(DrawingContext dc, Point screenPoint);

	/// <summary>Renders markers along graph</summary>
	public abstract class PointMarker : DependencyObject {

		/// <summary>Renders marker on screen</summary>
		/// <param name="dc">Drawing context to render marker on</param>
		/// <param name="dataPoint">Point from data source</param>
		/// <param name="screenPoint">Marker center coordinates on drawing context</param>
		public abstract void Render(DrawingContext dc, Point screenPoint);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="screenPoint"></param>
        /// <param name="mp"></param>
        public abstract void Render(DrawingContext dx, Point screenPoint, MarkersPoint mp);
		public static implicit operator PointMarker(MarkerRenderHandler renderer) {
            return FromRenderer(renderer);
		}

        public static PointMarker FromRenderer(MarkerRenderHandler renderer)
        {
            return new DelegatePointMarker(renderer);
        }
        
        public  List<float> Xs { get; set; }
        public List<MarkersPoint> markers{get;set;}
	}
    public class MarkersPoint
    {
        public float x { get; set; }
        public string desc { get; set; }
        public bool isdis { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(MarkersPoint)) return false;
            MarkersPoint C = obj as MarkersPoint;
            return (this.x == C.x);
        }
    }
    public class MarkersPointCompare : IEqualityComparer<MarkersPoint>
    {
        public static MarkersPointCompare Default = new MarkersPointCompare();
/*
        public bool Euqals(MarkersPoint x, MarkersPoint y)
        {
            return x.x.Equals(y.x);
        }
        public int GetHashCode(MarkersPoint obj)
        {
            return obj.GetHashCode();
        }*/

        bool IEqualityComparer<MarkersPoint>.Equals(MarkersPoint x, MarkersPoint y)
        {
            return x.x.Equals(y.x);
        }

        int IEqualityComparer<MarkersPoint>.GetHashCode(MarkersPoint obj)
        {
            return obj.GetHashCode();
        }
    }
}
