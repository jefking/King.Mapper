namespace King.Mapper.Integration
{
    using NUnit.Common;
    using NUnitLite;
    using System;
    using System.Reflection;

    public class Program
    {
        public static int Main(string[] args)
        {
            AutoRun ar;

#if NET35
            ar = new AutoRun();
#else
            ar = new AutoRun(typeof(Program).GetTypeInfo().Assembly);
#endif
            var writer = new ExtendedTextWrapper(Console.Out);
            var reader = Console.In;

            return ar.Execute(args, writer, reader);
        }
    }
}