using System.Reflection;
using Common.Logging;
using Spring.Aop;

namespace SpringWorkshop.CrossCutting.Aspects.Advices
{
    public class HelloWorldAdvice: IMethodBeforeAdvice
    {
	    private static ILog  log;

        public void Before(MethodInfo method, object[] args, object target)
        {
            log = LogManager.GetLogger(target.GetType());
            log.Info("HELLO WORLD");
        }
    }
}
