using System;
using System.Diagnostics;
using Trace = System.Diagnostics.Trace;

namespace Wall_E.Bot
{
	public static class Log
	{
		static Log()
		{
			Trace.AutoFlush = true;
			Trace.UseGlobalLock = true;
			Trace.Listeners.Add(new TextWriterTraceListener(Console.Out) { Name = "Console" });
			Trace.Listeners.Add(new FileTraceListenenr());
		}

		static string AddInfo(string message)
			=> DateTime.Now.ToString("[dd-MM-yyyy HH:mm:ss-zz]") + " " + message;

		public static void Info(string message)
			=> Trace.TraceInformation(AddInfo(message));

		public static void Info(string format, params object[] args)
			=> Info(string.Format(format, args));

		public static void Warn(string message)
			=> Trace.TraceWarning(AddInfo(message));

		public static void Warn(string format, params object[] args)
			=> Warn(string.Format(format, args));

		public static void Error(string message)
			=> Trace.TraceError(AddInfo(message));

		public static void Error(string format, params object[] args)
			=> Error(string.Format(format, args));
	}
}