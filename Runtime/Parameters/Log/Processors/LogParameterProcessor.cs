﻿using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    internal class LogParameterProcessor : ILogParameterProcessor
    {
        public void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue) { }
        public void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart) { }
    }
}