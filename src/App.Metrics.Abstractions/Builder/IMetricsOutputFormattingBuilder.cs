﻿// <copyright file="IMetricsOutputFormattingBuilder.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using App.Metrics.Formatters;

// ReSharper disable CheckNamespace
namespace App.Metrics
    // ReSharper restore CheckNamespace
{
    public interface IMetricsOutputFormattingBuilder
    {
        /// <summary>
        ///     <para>
        ///         Uses the specifed <see cref="IMetricsOutputFormatter"/> as one of the available formatters when reporting metric values.
        ///     </para>
        ///     <para>
        ///         Multiple formatters can be used, in which case the <see cref="IMetricsRoot.DefaultOutputMetricsFormatter"/> will be set to the first configured formatter.
        ///     </para>
        /// </summary>
        /// <param name="formatter">An <see cref="IMetricsOutputFormatter"/> instance used to format metric values when reporting.</param>
        /// <returns>
        ///     An <see cref="IMetricsBuilder" /> that can be used to further configure App Metrics.
        /// </returns>
        IMetricsBuilder Using(IMetricsOutputFormatter formatter);

        /// <summary>
        ///     <para>
        ///         Uses the specifed <see cref="IMetricsOutputFormatter"/> as one of the available formatters when reporting metric values.
        ///     </para>
        ///     <para>
        ///         Multiple formatters can be used, in which case the <see cref="IMetricsRoot.DefaultOutputMetricsFormatter"/> will be set to the first configured formatter.
        ///     </para>
        /// </summary>
        /// <typeparam name="TMetricsOutputFormatter">An <see cref="IMetricsOutputFormatter"/> type used to format metric values when reporting.</typeparam>
        /// <returns>
        ///     An <see cref="IMetricsBuilder" /> that can be used to further configure App Metrics.
        /// </returns>
        IMetricsBuilder Using<TMetricsOutputFormatter>()
            where TMetricsOutputFormatter : IMetricsOutputFormatter, new();
    }
}