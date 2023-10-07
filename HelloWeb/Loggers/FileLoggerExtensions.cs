﻿using HelloWeb.Providers;

namespace HelloWeb.Loggers
{
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filePath) {
            builder.AddProvider(new FileLoggerProvider(filePath));
            return builder;
        }
    }
}
