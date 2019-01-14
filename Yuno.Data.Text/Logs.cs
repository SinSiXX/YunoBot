﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuno.Data.Core.Interfaces;

namespace Yuno.Data.Text
{
    public class Logs : ILogs
    {
        private const string Directory = "Logs";

        private TextStream _stream = new TextStream();

        public void Log(string file, string data)
        {
            var directory = Path.Combine(Directory, file);
            var path = Path.Combine(directory, $"{DateTime.Today:yy-MM-dd}.txt");
            if (!System.IO.Directory.Exists(directory)) System.IO.Directory.CreateDirectory(directory);
            _stream.WriteLine(path, $"[{DateTime.Now.ToShortTimeString()}] {data}");
        }
    }
}
