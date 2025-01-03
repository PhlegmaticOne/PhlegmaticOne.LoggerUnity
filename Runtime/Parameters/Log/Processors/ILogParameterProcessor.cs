﻿using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Parameters.Log.Processors
{
    public interface ILogParameterProcessor
    {
        void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue);
        void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart);
    }
}