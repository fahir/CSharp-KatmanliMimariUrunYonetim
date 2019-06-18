using PostSharp.Aspects;
using System;
using System.Diagnostics;
using System.Reflection;
using OZBAY.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace OZBAY.Core.Aspects.PostSharp.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private int _interval;
        [NonSerialized]
        private Stopwatch _stopWatch;
        [NonSerialized]
        private LoggerService _loggerService;
        private readonly Type _loggerType;

        public PerformanceCounterAspect(int interval = 5, Type loggerType = null)
        {
            _interval = interval;
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType != null)
            {
                if (_loggerType.BaseType != typeof(LoggerService))
                    throw new Exception("Wrong Logger Type");

                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
                _stopWatch = Activator.CreateInstance<Stopwatch>();

            }
            base.RuntimeInitialize(method);

        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopWatch.Start();
            base.OnEntry(args);

        }
        public override void OnExit(MethodExecutionArgs args)
        {


            _stopWatch.Stop();
            if (_stopWatch.Elapsed.TotalSeconds > _interval)
            {
                string format = ("Date: {0},\nClass Name: {1},\nMethod Name: {2},\nElapsed Time:{3}");

                string body = string.Format(format, DateTime.Now, args.Method.DeclaringType.FullName, args.Method.Name, _stopWatch.Elapsed.TotalSeconds);

                if (_loggerService != null)
                {
                    _loggerService.Warn(body);
                }

            }
            _stopWatch.Reset();
            base.OnExit(args);
        }
    }
}
