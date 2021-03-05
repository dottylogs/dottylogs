using System.Threading;

namespace DottyLogs.Client
{
    public static class DottyLogsScopedContextAccessor
    {
        private static AsyncLocal<DottyLogsScopedContextHolder> _scopedContextCurrent = new AsyncLocal<DottyLogsScopedContextHolder>();

        public static bool IsInSpan => _scopedContextCurrent.Value != null;
        public static DottyLogsScopedContext? DottyLogsScopedContext
        {
            get
            {
                return _scopedContextCurrent.Value?.Context;
            }
            set
            {
                var holder = _scopedContextCurrent.Value;
                if (holder != null)
                {
                    // Clear current Context trapped in the AsyncLocals, as its done.
                    holder.Context = null;
                }

                if (value != null)
                {
                    // Use an object indirection to hold the HttpContext in the AsyncLocal,
                    // so it can be cleared in all ExecutionContexts when its cleared.
                    _scopedContextCurrent.Value = new DottyLogsScopedContextHolder { Context = value };
                }
            }
        }

        private class DottyLogsScopedContextHolder
        {
            public DottyLogsScopedContext? Context;
        }
    }

    public class DottyLogsScopedContext
    {
        public string SpanId { get; set; }
    }
}
