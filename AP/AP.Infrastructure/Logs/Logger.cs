using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AP.Infrastructure.Logs
{
    public class Logger
    {
        public enum LogType
        {
            Trace,
            Debug,
            Info,
            Warning,
            Error,
            Fatal,
            TraceOveride
        }

        private static string LogPath
        {
            get
            {
                var absolutePath = new Uri(Assembly.GetExecutingAssembly().EscapedCodeBase).AbsolutePath;
                if (!string.IsNullOrEmpty(StaticVariable.LogPath))
                    absolutePath = absolutePath.Substring(0, absolutePath.IndexOf("/bin") + 1) +
                                   StaticVariable.LogPath + "/Logs/";
                else
                    absolutePath = absolutePath.Substring(0, absolutePath.IndexOf("/bin") + 1) + "Logs/";

                //absolutePath = !string.IsNullOrEmpty(AppSettings.Instance.GetString("LogPath")) ? AppSettings.Instance.GetString("LogPath") : (absolutePath.Substring(0, absolutePath.IndexOf("/bin") + 1) + "wwwroot/Logs/");
                try
                {
                    if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                }
                catch (Exception ex)
                {
                }

                return absolutePath;
            }
        }

        private static void Init()
        {
            var configuration = new LoggingConfiguration();

            var target = new FileTarget();
            configuration.AddTarget("file", target);
            target.FileName = LogPath + "${date:format=yyyyMMdd}/TraceLog.txt";
            target.Layout = "${date:format=HH\\:mm\\:ss}\t${message}\t${logger}\t${stacktrace}";
            var item = new LoggingRule("*", target);
            item.EnableLoggingForLevel(LogLevel.Trace);
            configuration.LoggingRules.Add(item);

            var target2 = new FileTarget();
            configuration.AddTarget("file", target2);
            target2.FileName = LogPath + "${date:format=yyyyMMdd}/DebugLog.txt";
            target2.Layout = "${date:format=HH\\:mm\\:ss}\t${message}\t${logger}\t${stacktrace}";
            var rule2 = new LoggingRule("*", target2);
            rule2.EnableLoggingForLevel(LogLevel.Debug);
            configuration.LoggingRules.Add(rule2);

            var target3 = new FileTarget();
            configuration.AddTarget("file", target3);
            target3.FileName = LogPath + "${date:format=yyyyMMdd}/InfoLog.txt";
            target3.Layout = "${date:format=HH\\:mm\\:ss}\t${message}\t${logger}\t${stacktrace}";
            var rule3 = new LoggingRule("*", target3);
            rule3.EnableLoggingForLevel(LogLevel.Info);
            configuration.LoggingRules.Add(rule3);

            var target4 = new FileTarget();
            configuration.AddTarget("file", target4);
            target4.FileName = LogPath + "${date:format=yyyyMMdd}/WarnLog.txt";
            target4.Layout = "${date:format=HH\\:mm\\:ss}\t${message}\t${logger}\t${stacktrace}";
            var rule4 = new LoggingRule("*", target4);
            rule4.EnableLoggingForLevel(LogLevel.Warn);
            configuration.LoggingRules.Add(rule4);

            var target5 = new FileTarget();
            configuration.AddTarget("file", target5);
            target5.FileName = LogPath + "${date:format=yyyyMMdd}/ErrorLog.txt";
            target5.Layout = "${date:format=HH\\:mm\\:ss}\t${message}\t${logger}\t${stacktrace}";
            var rule5 = new LoggingRule("*", target5);
            rule5.EnableLoggingForLevel(LogLevel.Error);
            configuration.LoggingRules.Add(rule5);

            var target6 = new FileTarget();
            configuration.AddTarget("file", target6);
            target6.FileName = LogPath + "${date:format=yyyyMMdd}/FatalLog.txt";
            target6.Layout = "${date:format=HH\\:mm\\:ss}\t${message}\t${logger}\t${stacktrace}";
            var rule6 = new LoggingRule("*", target6);
            rule6.EnableLoggingForLevel(LogLevel.Fatal);
            configuration.LoggingRules.Add(rule6);

            LogManager.Configuration = configuration;
        }

        public static void TraceLog(object content)
        {
            if (LogManager.Configuration == null) Init();
            var logger = LogManager.GetLogger(new StackFrame(1).GetMethod().Name);
            logger.Trace(content);
        }

        public static void WriteLog(LogType logType, object content)
        {
            if (LogManager.Configuration == null) Init();
            var logger = LogManager.GetLogger(new StackFrame(1).GetMethod().Name);
            switch (logType)
            {
                case LogType.Trace:
                    logger.Trace(content);
                    return;

                case LogType.Debug:
                    logger.Debug(content);
                    return;

                case LogType.Warning:
                    logger.Warn(content);
                    return;

                case LogType.Error:
                    logger.Error(content);
                    return;

                case LogType.Fatal:
                    logger.Fatal(content);
                    return;
            }

            logger.Info(content);
        }

        public static void WriteLog(LogType logType, string content)
        {
            if (LogManager.Configuration == null) Init();
            var logger = LogManager.GetLogger(new StackFrame(1).GetMethod().Name);
            switch (logType)
            {
                case LogType.Trace:
                    logger.Trace(content);
                    return;

                case LogType.Debug:
                    logger.Debug(content);
                    return;

                case LogType.Warning:
                    logger.Warn(content);
                    return;

                case LogType.Error:
                    logger.Error(content);
                    return;

                case LogType.Fatal:
                    logger.Fatal(content);
                    return;
            }

            logger.Info(content);
        }

        public static void WriteLog(LogType logType, string content, LogParam logParam)
        {
            if (LogManager.Configuration == null) Init();
            var logger = LogManager.GetLogger(new StackFrame(1).GetMethod().Name);
            switch (logType)
            {
                case LogType.Trace:
                    logger.Trace(content);
                    foreach (var pair in logParam.Attribute) logger.Trace("$[{pair.Key}:{pair.Value}]");
                    return;

                case LogType.Debug:
                    logger.Debug(content);
                    foreach (var pair2 in logParam.Attribute) logger.Debug("$[{pair2.Key}:{pair2.Value}]");
                    return;

                case LogType.Warning:
                    logger.Warn(content);
                    foreach (var pair3 in logParam.Attribute) logger.Warn("$[{pair3.Key}:{pair3.Value}]");
                    return;

                case LogType.Error:
                    logger.Error(content);
                    foreach (var pair4 in logParam.Attribute) logger.Error("$[{pair4.Key}:{pair4.Value}]");
                    return;

                case LogType.Fatal:
                    logger.Fatal(content);
                    foreach (var pair5 in logParam.Attribute) logger.Fatal("$[{pair5.Key}:{pair5.Value}]");
                    return;
            }

            logger.Info(content);
            foreach (var pair6 in logParam.Attribute) logger.Info("$[{pair6.Key}:{pair6.Value}]");
        }

        public static void ErrorLog(object content)
        {
            WriteLog(LogType.Error, content);
        }

        public static void ErrorLog(string content)
        {
            WriteLog(LogType.Error, content);
        }

        public static void FatalLog(object content)
        {
            WriteLog(LogType.Fatal, content);
        }

        public static void FatalLog(string content)
        {
            WriteLog(LogType.Fatal, content);
        }

        public static void Error(Exception ex)
        {
            throw new NotImplementedException();
        }

        [Serializable]
        public class LogParam
        {
            public LogParam()
            {
                Attribute = new Dictionary<string, object>();
            }

            public Dictionary<string, object> Attribute { get; set; }

            public object this[string attribute]
            {
                get
                {
                    if (!Attribute.ContainsKey(attribute)) return null;
                    return Attribute[attribute];
                }
                set
                {
                    if (Attribute.ContainsKey(attribute))
                        Attribute[attribute] = value;
                    else
                        Attribute.Add(attribute, value);
                }
            }
        }
    }
}