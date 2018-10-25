using System;
using System.Diagnostics;
using System.IO;

namespace Wall_E.Música
{
	public class FileTraceListenenr : TraceListener
	{
		readonly StreamWriter writer;
		readonly object locker = new object();

		public FileTraceListenenr()
			: base("file")
		{
			var file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(),
				"Logs",
				$"Wall-E-{DateTime.Now.ToString("dd-MM-yyyy")}.log"));

			if (!file.Directory.Exists)
				file.Directory.Create();

			if (!file.Exists)
				writer = file.CreateText();
			else
				writer = file.AppendText();

			file.Refresh();

			if(file.Length > 0) {
				for (var i = 0; i < 32; i++)
					writer.Write("-");

				writer.WriteLine();
			}
		}

		public override void Write(string message) {
			lock (locker) {
				writer.Write(message);
				writer.Flush();
			}
		}

		public override void WriteLine(string message) {
			lock (locker) {
				writer.WriteLine(message);
				writer.Flush();
			}
		}
	}
}