using System.Windows;
using System.Windows.Media;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
using Microsoft.Research.DynamicDataDisplay.Common;
using System.Collections.Generic;
using System;

namespace Microsoft.Research.DynamicDataDisplay
{
    public  class Step
    {
        public static float len = 0.325f;
    }
	public class MarkerPointsGraph : PointsGraphBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MarkerPointsGraph"/> class.
		/// </summary>
		public MarkerPointsGraph()
		{
			ManualTranslate = true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MarkerPointsGraph"/> class.
		/// </summary>
		/// <param name="dataSource">The data source.</param>
		public MarkerPointsGraph(IPointDataSource dataSource)
			: this()
		{
			DataSource = dataSource;
		}

		protected override void OnVisibleChanged(DataRect newRect, DataRect oldRect)
		{
			base.OnVisibleChanged(newRect, oldRect);
			InvalidateVisual();
		}

		public PointMarker Marker
		{
			get { return (PointMarker)GetValue(MarkerProperty); }
			set { SetValue(MarkerProperty, value); }
		}

		public static readonly DependencyProperty MarkerProperty =
			DependencyProperty.Register(
			  "Marker",
			  typeof(PointMarker),
			  typeof(MarkerPointsGraph),
			  new FrameworkPropertyMetadata { DefaultValue = null, AffectsRender = true }
				  );

		protected override void OnRenderCore(DrawingContext dc, RenderState state)
		{
			if (DataSource == null) return;
			if (Marker == null) return;
            if (Marker.markers == null) return;
            
			var transform = Plotter2D.Viewport.Transform;

			DataRect bounds = DataRect.Empty;
            IEnumerable<Point> ps = GetPoints();//实际值
            List<Point> buf = new List<Point>(ps);
            if (buf.Count < 1) return;
            double xstart = buf[0].X;
            foreach (MarkersPoint mp in Marker.markers)
            {
                try
                {
                    int idx = (int)((mp.x - xstart) / Step.len);
                    Point screenPoint = buf[idx].DataToScreen(transform);
                    bounds = DataRect.Union(bounds, buf[idx]);
                    Marker.Render(dc, screenPoint, mp);//画标记
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            Viewport2D.SetContentBounds(this, bounds);
            return;
			using (IPointEnumerator enumerator = DataSource.GetEnumerator(GetContext()))
			{
				Point point = new Point();
                int i = 0;
                
				while (enumerator.MoveNext())
				{
                    
					enumerator.GetCurrent(ref point);
                    if (!Marker.markers.Contains(new MarkersPoint { x = (float)point.X })) continue;
                     enumerator.ApplyMappings(Marker);
                     i++;
                     MarkersPoint mp = Marker.markers[i - 1];
					//Point screenPoint = point.Transform(state.Visible, state.Output);
					Point screenPoint = point.DataToScreen(transform);

					bounds = DataRect.Union(bounds, point);
					Marker.Render(dc, screenPoint,mp);//画标记
				}
			}

			Viewport2D.SetContentBounds(this, bounds);
		}
	}

}
