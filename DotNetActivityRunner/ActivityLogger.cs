using Microsoft.Azure.Management.DataFactories.Runtime;
using System;

namespace DotNetActivityRunner
{
    public class ActivityLogger : IActivityLogger
    {
        public ActivityLogger()
        {
        }

        public void Write(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}