// Copyright (c) Autofac Project. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Autofac.Core.Resolving;
using Autofac.Core.Resolving.Pipeline;

namespace Autofac.Core.Diagnostics
{
    /// <summary>
    /// Diagnostic data associated with resolve request events.
    /// </summary>
    public class RequestDiagnosticData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestDiagnosticData"/> class.
        /// </summary>
        /// <param name="operation">The pipeline resolve operation that this request is running within.</param>
        /// <param name="requestContext">The context for the resolve request that is running.</param>
        public RequestDiagnosticData(ResolveOperationBase operation, ResolveRequestContextBase requestContext)
        {
            Operation = operation;
            RequestContext = requestContext;
        }

        /// <summary>
        /// Gets the pipeline resolve operation that this request is running within.
        /// </summary>
        public ResolveOperationBase Operation { get; private set; }

        /// <summary>
        /// Gets the context for the resolve request that is running.
        /// </summary>
        public ResolveRequestContextBase RequestContext { get; private set; }
    }
}
