﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AssetNXT.Model;
using Microsoft.AspNetCore.Routing.Constraints;

namespace AssetNXT.Logic
{
    public class OutOfBounds
    {
        private List<PointModel> Points { get; set; }

        // Temporary hard-coded, will be replaced later
        private double _radius;
        private PointModel _middleCircle;
        private PointModel _markerPoint;
        private AssetModel _assetModel;

        public OutOfBounds(AssetModel asset, PointModel middleCircle, double radius, PointModel markerPoint)
        {
            _assetModel = asset;
            _middleCircle = middleCircle;
            _radius = radius;
            _markerPoint = markerPoint;
        }

        public OutOfBounds(AssetModel asset, PointModel markerPoint, List<PointModel> points)
        {
            _assetModel = asset;
            _markerPoint = markerPoint;
            Points = points;
        }

        public AssetModel PointInCircle()
        {
            // (MarkerX - MiddlepointX)^2 + (MarkerY - MiddlepointY)^2 = radius^2
            double result = Math.Sqrt(Math.Pow(_markerPoint.Latitude - _middleCircle.Latitude, 2) + Math.Pow(_markerPoint.Longtitude - _middleCircle.Longtitude, 2));

            // Uses Pythagorean theorem to calculate the distance from the middle of the circle.
            // == Outer of the circle (returns false)
            // <  Inside the circle (returns false)
            // >  Outside of the circle (returns true)
            if (result <= _radius)
            {
                _assetModel.OutOfBounds = false;
                return _assetModel;
            }
            else
            {
                _assetModel.OutOfBounds = true;
                return _assetModel;
            }
        }

        public AssetModel PointInTriangle()
        {
            // latitude, x, horizontal
            // longtitude, y, vertical
            // The marker lies inside the triangle when the following conditions are met:
            // vector >= 0
            // vector2 >= 0
            // vector + vector2 <= 1

            // vector = numerator / denominator
            // numerator = Point A Latitude * (Point C Longtitude - Point A Longtitude) + (Marker Longtitude - Point A Longtitude) * (Point C Latitude - Point A Latitude) - Marker Latitude * (Point C Longtitude - Point A Longtitude
            // denominator = (Point B Longtitude - Point A Longtitude) * (Point C Latitude - Point A Latitude) - (Point B Latitude - Point A Latitude) * (Point C Longtitude - Point A Longtitude)
            double numerator = (Points[0].Latitude * (Points[2].Longtitude - Points[0].Longtitude)) + ((_markerPoint.Longtitude - Points[0].Longtitude) * (Points[2].Latitude - Points[0].Latitude)) - (_markerPoint.Latitude * (Points[2].Longtitude - Points[0].Longtitude));
            double denominator = ((Points[1].Longtitude - Points[0].Longtitude) * (Points[2].Latitude - Points[0].Latitude)) - ((Points[1].Latitude - Points[0].Latitude) * (Points[2].Longtitude - Points[0].Longtitude));
            double vector = numerator / denominator;

            // numerator2 = Marker Longtitude - Point A Longtitude - vector * (Point B Longtitude - Point A Longtitude)
            // denominator2 = Point C Longtitude - Point A Longtitude
            double numerator2 = _markerPoint.Longtitude - Points[0].Longtitude - (vector * (Points[1].Longtitude - Points[0].Longtitude));
            double denominator2 = Points[2].Longtitude - Points[0].Longtitude;
            double vector2 = numerator2 / denominator2;

            if (vector >= 0.0 && vector2 >= 0 && vector + vector2 <= 1.0)
            {
                _assetModel.OutOfBounds = false;
                return _assetModel;
            }
            else
            {
                _assetModel.OutOfBounds = true;
                return _assetModel;
            }
        }
    }
}