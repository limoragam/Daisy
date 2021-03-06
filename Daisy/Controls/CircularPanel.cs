﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace daisy.Controls
{
    public class CircularPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Children)
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            return base.MeasureOverride(availableSize);
        }

        // Arrange stuff in a circle
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count > 0)
            {
                // Center & radius of panel
                Point center = new Point(finalSize.Width / 2, finalSize.Height / 2);
                double radius = Math.Min(finalSize.Width, finalSize.Height) / 2.0;
                Size childSize = new Size(Children[0].DesiredSize.Width, Children[0].DesiredSize.Height);
                radius -= childSize.Height/2.0; // radius should reach middle of child height

                // # radians between children
                double angleIncrRadians = 2.0 * Math.PI / Children.Count;
                double angleInRadians = -0.5 * Math.PI; // Starting point: top center

                foreach (UIElement child in Children)
                {
                    Point childPosition = new Point(
                        radius * Math.Cos(angleInRadians) + center.X - child.DesiredSize.Width / 2,
                        radius * Math.Sin(angleInRadians) + center.Y - child.DesiredSize.Height / 2);

                    child.Arrange(new Rect(childPosition, child.DesiredSize));

                    angleInRadians += angleIncrRadians;
                }
            }

            return finalSize;
        }
    }
}
