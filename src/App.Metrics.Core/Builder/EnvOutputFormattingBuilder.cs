﻿// <copyright file="EnvOutputFormattingBuilder.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Formatters;

// ReSharper disable CheckNamespace
namespace App.Metrics
    // ReSharper restore CheckNamespace
{
    /// <summary>
    ///     Builder for configuring environment information output formatting using an <see cref="IMetricsBuilder" />.
    /// </summary>
    public class EnvOutputFormattingBuilder : IEnvOutputFormattingBuilder
    {
        private readonly IMetricsBuilder _metricsBuilder;
        private readonly Action<IEnvOutputFormatter> _formatter;

        internal EnvOutputFormattingBuilder(
            IMetricsBuilder metricsBuilder,
            Action<IEnvOutputFormatter> formatter)
        {
            _metricsBuilder = metricsBuilder ?? throw new ArgumentNullException(nameof(metricsBuilder));
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        /// <inheritdoc />
        public IMetricsBuilder Using(IEnvOutputFormatter formatter)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            _formatter(formatter);

            return _metricsBuilder;
        }

        /// <inheritdoc />
        public IMetricsBuilder Using<TEvnOutputFormatter>()
            where TEvnOutputFormatter : IEnvOutputFormatter, new()
        {
            _formatter(new TEvnOutputFormatter());

            return _metricsBuilder;
        }
    }
}
