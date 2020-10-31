using System;
using System.Diagnostics;
using Autofac.Diagnostics;

namespace Autofac
{
    /// <summary>
    /// Extensions to the container builder to provide convenience methods for tracing.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Subscribes a diagnostic tracer to Autofac events.
        /// </summary>
        /// <param name="builder">The builder with the diagnostics to which you want to subscribe.</param>
        /// <param name="tracer">A diagnostic tracer that will be subscribed to all diagnostic events once the container is built.</param>
        /// <remarks>
        /// <para>
        /// This is a convenience method that attaches the <paramref name="tracer"/> to the
        /// <see cref="DiagnosticListener"/> associated with the <paramref name="builder"/>. If you
        /// have an event listener that isn't a <see cref="DiagnosticTracerBase"/> you can
        /// use standard <see cref="DiagnosticListener"/> semantics to subscribe to the events
        /// with your custom listener.
        /// </para>
        /// </remarks>
        public static void SubscribeToDiagnostics(this ContainerBuilder builder, DiagnosticTracerBase tracer)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (tracer is null)
            {
                throw new ArgumentNullException(nameof(tracer));
            }

            builder.DiagnosticSource.Subscribe(tracer, tracer.IsEnabled);
        }

        /// <summary>
        /// Subscribes a diagnostic tracer to Autofac events.
        /// </summary>
        /// <typeparam name="T">
        /// The type of diagnostic tracer that will be subscribed to the container's diagnostic source once it is built.
        /// </typeparam>
        /// <param name="builder">The builder with the diagnostics to which you want to subscribe.</param>
        /// <returns>
        /// The diagnostic tracer that was created and attached to the diagnostic source. Use
        /// this instance to enable or disable the messages that should be handled.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This is a convenience method that attaches a tracer to the
        /// <see cref="DiagnosticListener"/> associated with the <paramref name="builder"/>. If you
        /// have an event listener that isn't a <see cref="DiagnosticTracerBase"/> you can
        /// use standard <see cref="DiagnosticListener"/> semantics to subscribe to the events
        /// with your custom listener.
        /// </para>
        /// </remarks>
        public static T SubscribeToDiagnostics<T>(this ContainerBuilder builder)
            where T : DiagnosticTracerBase, new()
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var tracer = new T();
            builder.SubscribeToDiagnostics(tracer);
            return tracer;
        }
    }
}
