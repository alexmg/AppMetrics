﻿// <copyright file="MetricsClockBuilder.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Infrastructure;

// ReSharper disable CheckNamespace
namespace App.Metrics
    // ReSharper restore CheckNamespace
{
    /// <summary>
    ///     Builder for configuring the <see cref="IClock"/> used for timing when recording specific metrics types e.g. <see cref="MetricType.Timer"/>.
    /// </summary>
    public class MetricsClockBuilder : IMetricsClockBuilder
    {
        private readonly Action<IClock> _clock;
        private readonly IMetricsBuilder _metricsBuilder;

        internal MetricsClockBuilder(
            IMetricsBuilder metricsBuilder,
            Action<IClock> clock)
        {
            _metricsBuilder = metricsBuilder ?? throw new ArgumentNullException(nameof(metricsBuilder));
            _clock = clock ?? throw new ArgumentNullException(nameof(clock));
        }

        /// <inheritdoc />
        public IMetricsBuilder Clock(IClock clock)
        {
            if (clock == null)
            {
                throw new ArgumentNullException(nameof(clock));
            }

            _clock(clock);

            return _metricsBuilder;
        }

        /// <inheritdoc />
        public IMetricsBuilder Clock<TClock>()
            where TClock : class, IClock, new()
        {
            _clock(new TClock());

            return _metricsBuilder;
        }

        /// <inheritdoc />
        public IMetricsBuilder StopwatchClock()
        {
            Clock<StopwatchClock>();

            return _metricsBuilder;
        }

        /// <inheritdoc />
        public IMetricsBuilder SystemClock()
        {
            Clock<SystemClock>();

            return _metricsBuilder;
        }
    }
}