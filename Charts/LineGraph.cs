﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.Charts.Legend_items;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.Filters;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;


namespace Microsoft.Research.DynamicDataDisplay
{
	/// <summary>
	/// Represents a series of points connected by one polyline.
	/// </summary>
    public class LineGraph : PointsGraphBase
    {
        static LineGraph()
        {
            Type thisType = typeof(LineGraph);

            NewLegend.DescriptionProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata("LineGraph"));
            NewLegend.LegendItemsBuilderProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(new LegendItemsBuilder(DefaultLegendItemsBuilder)));
        }

        private static IEnumerable<FrameworkElement> DefaultLegendItemsBuilder(IPlotterElement plotterElement)
        {
            LineGraph lineGraph = (LineGraph)plotterElement;

            Line line = new Line { X1 = 0, Y1 = 10, X2 = 20, Y2 = 0, Stretch = Stretch.Fill, DataContext = lineGraph };
            line.SetBinding(Line.StrokeProperty, "Stroke");
            line.SetBinding(Line.StrokeThicknessProperty, "StrokeThickness");
            NewLegend.SetVisualContent(lineGraph, line);

            var legendItem = LegendItemsHelper.BuildDefaultLegendItem(lineGraph);
            yield return legendItem;
        }

        private readonly FilterCollection filters = new FilterCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="LineGraph"/> class.
        /// </summary>
        public LineGraph()
        {
            Legend.SetVisibleInLegend(this, true);
            ManualTranslate = true;

            filters.CollectionChanged += filters_CollectionChanged;
        }

        private void filters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            filteredPoints = null;
            Update();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineGraph"/> class.
        /// </summary>
        /// <param name="pointSource">The point source.</param>
        public LineGraph(IPointDataSource pointSource)
            : this()
        {
            DataSource = pointSource;
        }

        protected override Description CreateDefaultDescription()
        {
            return new PenDescription();
        }

        /// <summary>Provides access to filters collection</summary>
        public FilterCollection Filters
        {
            get { return filters; }
        }

        #region Pen

        /// <summary>
        /// Gets or sets the brush, using which polyline is plotted.
        /// </summary>
        /// <value>The line brush.</value>
        public Brush Stroke
        {
            get { return LinePen.Brush; }
            set
            {
                if (LinePen.Brush != value)
                {
                    if (!LinePen.IsSealed)
                    {
                        LinePen.Brush = value;
                        InvalidateVisual();
                    }
                    else
                    {
                        Pen pen = LinePen.Clone();
                        pen.Brush = value;
                        LinePen = pen;
                    }

                    RaisePropertyChanged("Stroke");
                }
            }
        }

        /// <summary>
        /// Gets or sets the line thickness.
        /// </summary>
        /// <value>The line thickness.</value>
        public double StrokeThickness
        {
            get { return LinePen.Thickness; }
            set
            {
                if (LinePen.Thickness != value)
                {
                    if (!LinePen.IsSealed)
                    {
                        LinePen.Thickness = value; InvalidateVisual();
                    }
                    else
                    {
                        Pen pen = LinePen.Clone();
                        pen.Thickness = value;
                        LinePen = pen;
                    }

                    RaisePropertyChanged("StrokeThickness");
                }
            }
        }

        /// <summary>
        /// Gets or sets the line pen.
        /// </summary>
        /// <value>The line pen.</value>
        [NotNull]
        public Pen LinePen
        {
            get { return (Pen)GetValue(LinePenProperty); }
            set { SetValue(LinePenProperty, value); }
        }

        public static readonly DependencyProperty LinePenProperty =
            DependencyProperty.Register(
            "LinePen",
            typeof(Pen),
            typeof(LineGraph),
            new FrameworkPropertyMetadata(
                new Pen(Brushes.Blue, 1),
                FrameworkPropertyMetadataOptions.AffectsRender
                ),
            OnValidatePen);

        private static bool OnValidatePen(object value)
        {
            return value != null;
        }

        #endregion

        protected override void OnOutputChanged(Rect newRect, Rect oldRect)
        {
            filteredPoints = null;
            base.OnOutputChanged(newRect, oldRect);
        }

        protected override void OnDataChanged()
        {
            filteredPoints = null;
            base.OnDataChanged();
        }

        protected override void OnDataSourceChanged(DependencyPropertyChangedEventArgs args)
        {
            filteredPoints = null;
            base.OnDataSourceChanged(args);
        }

        protected override void OnVisibleChanged(DataRect newRect, DataRect oldRect)
        {
            if (newRect.Size != oldRect.Size)
            {
                filteredPoints = null;
            }

            base.OnVisibleChanged(newRect, oldRect);
        }

        private FakePointList filteredPoints;//实际屏幕上的点
        protected FakePointList FilteredPoints
        {
            get { return filteredPoints; }
            set { filteredPoints = value; }
        }
      /*  FakePointList filteredMarkerPoints;//标记点在屏幕上显示的位置*/
        protected override void UpdateCore()
        {
            if (DataSource == null) return;
            if (Plotter == null) return;

            Rect output = Viewport.Output;
            var transform = GetTransform();

            if (filteredPoints == null || !(transform.DataTransform is IdentityTransform))
            {
                IEnumerable<Point> points = GetPoints();//实际值
                Point[] ps = points.ToArray<Point>();
               /* List<Point> ps=points.ToList<Point>();
                List<Point> pps = new List<Point>();
                if (myPointMarkers != null)
                {
                    foreach (MyPointMarker mp in myPointMarkers)
                    {
                        Point point = ps.Find(
                            delegate(Point p)
                            {
                                return p.X == mp.x;
                            });
                        pps.Add(point);
                    }
                }*/
                var bounds = BoundsHelper.GetViewportBounds(points, transform.DataTransform);
                Viewport2D.SetContentBounds(this, bounds);

                // getting new value of transform as it could change after calculating and setting content bounds.
                transform = GetTransform();
                List<Point> transformedPoints = transform.DataToScreenAsList(points);//屏幕上显示值
                /*List<Point> transformedMarkerPoints = transform.DataToScreenAsList(pps);*/
                // Analysis and filtering of unnecessary points,
                // 分析和过滤不必要的点
                filteredPoints = new FakePointList(FilterPoints(transformedPoints),
                    output.Left, output.Right);//过滤超出屏幕的点
                /*filteredMarkerPoints = new FakePointList(FilterPoints(transformedMarkerPoints), output.Left, output.Right);*/
                if (ProvideVisiblePoints)
                {
                    List<Point> viewportPointsList = new List<Point>(transformedPoints.Count);
                    if (transform.DataTransform is IdentityTransform)
                    {
                        viewportPointsList.AddRange(points);
                    }
                    else
                    {
                        var viewportPoints = points.DataToViewport(transform.DataTransform);
                        viewportPointsList.AddRange(viewportPoints);
                    }

                    SetVisiblePoints(this, new ReadOnlyCollection<Point>(viewportPointsList));
                }

                Offset = new Vector();
            }
            else
            {
                double left = output.Left;
                double right = output.Right;
                double shift = Offset.X;
                left -= shift;
                right -= shift;

                filteredPoints.SetXBorders(left, right);
            }
        }

        StreamGeometry streamGeometry = new StreamGeometry();
        protected override void OnRenderCore(DrawingContext dc, RenderState state)
        {
            if (DataSource == null) return;

            if (filteredPoints.HasPoints)//存在点
            {

                using (StreamGeometryContext context = streamGeometry.Open())
                {
                    context.BeginFigure(filteredPoints.StartPoint, false, false);
                    context.PolyLineTo(filteredPoints, true, smoothLinesJoin);//画线
                }
                //画标记点
  /*              if (filteredMarkerPoints != null)
                    foreach (Point point in filteredMarkerPoints.points)
                    {
                        DrawPointMarker(dc, point);
                    }*/

                Brush brush = null;
                Pen pen = LinePen;

                bool isTranslated = IsTranslated;
                if (isTranslated)
                {
                    dc.PushTransform(new TranslateTransform(Offset.X, Offset.Y));
                }
                dc.DrawGeometry(brush, pen, streamGeometry);
                if (isTranslated)
                {
                    dc.Pop();
                }

#if __DEBUG
				FormattedText text = new FormattedText(filteredPoints.Count.ToString(),
					CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
					new Typeface("Arial"), 12, Brushes.Black);
				dc.DrawText(text, Viewport.Output.GetCenter());
#endif
            }
        }

        private bool filteringEnabled = true;
        public bool FilteringEnabled
        {
            get { return filteringEnabled; }
            set
            {
                if (filteringEnabled != value)
                {
                    filteringEnabled = value;
                    filteredPoints = null;
                    Update();
                }
            }
        }

        private bool smoothLinesJoin = true;
        public bool SmoothLinesJoin
        {
            get { return smoothLinesJoin; }
            set
            {
                smoothLinesJoin = value;
                Update();
            }
        }

        private List<Point> FilterPoints(List<Point> points)
        {
            if (!filteringEnabled)
                return points;

            var filteredPoints = filters.Filter(points, Viewport.Output);

            return filteredPoints;
        }
/*
        private List<MyPointMarker> _mypointmarkers;
        public List<MyPointMarker> myPointMarkers
        {
            get { return _mypointmarkers; }
            set { _mypointmarkers = value; }
        }
        private void DrawPointMarker(DrawingContext dx, Point screenPoint, MyPointMarker mp)
        {
            dx.DrawEllipse(Brushes.Red,new Pen(), screenPoint, 10 / 2, 10 / 2);

            dx.DrawText(new FormattedText(mp.desc == "" ? "null" : mp.desc,//s
                System.Globalization.CultureInfo.GetCultureInfo("zh-cn"),
                FlowDirection.LeftToRight,
                  new Typeface("Verdana"),
                  8,
                  Brushes.Black), screenPoint);
        }
        private void DrawPointMarker(DrawingContext dc, Point screenPoint)
        {
            dc.DrawEllipse(Brushes.Red, new Pen(), screenPoint, 10 / 2, 10 / 2);

            dc.DrawText(new FormattedText("M1",//s
                System.Globalization.CultureInfo.GetCultureInfo("zh-cn"),
                FlowDirection.LeftToRight,
                  new Typeface("Verdana"),
                  8,
                  Brushes.Black), screenPoint);
        }*/
    }
}
