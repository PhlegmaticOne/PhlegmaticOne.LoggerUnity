using System;
using System.Diagnostics;
using System.Reflection;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;

namespace OpenMyGame.LoggerUnity.Infrastructure.Stacktrace
{
    public static class StacktraceBuilder
    {
        public static void Build(ref SpanStringBuilder stringBuilder, StackTrace stackTrace)
        {
            var flag2 = true;

            for (var i = 0; i < stackTrace.FrameCount; ++i)
            {
                var frame = stackTrace.GetFrame(i);
                var method = frame.GetMethod();

                if (method == null)
                {
                    continue;
                }

                if (flag2)
                {
                    flag2 = false;
                }
                else
                {
                    stringBuilder.Append(Environment.NewLine);
                }

                stringBuilder.Append("   at ");

                var declaringType = method.DeclaringType;

                if (declaringType != null)
                {
                    stringBuilder.Append(declaringType.FullName);
                    stringBuilder.Append('.');
                }

                stringBuilder.Append(method.Name);

                if ((object)(method as MethodInfo) != null && method.IsGenericMethod)
                {
                    var genericArguments = method.GetGenericArguments();
                    stringBuilder.Append('[');
                    var flag3 = true;

                    for (var index2 = 0; index2 < genericArguments.Length; ++index2)
                    {
                        if (!flag3)
                        {
                            stringBuilder.Append(',');
                        }
                        else
                        {
                            flag3 = false;
                        }

                        stringBuilder.Append(genericArguments[index2].Name);
                    }

                    stringBuilder.Append(']');
                }

                stringBuilder.Append('(');

                var parameters = method.GetParameters();
                var flag4 = true;

                for (var index3 = 0; index3 < parameters.Length; ++index3)
                {
                    if (!flag4)
                    {
                        stringBuilder.Append(',');
                        stringBuilder.Append(' ');
                    }
                    else
                    {
                        flag4 = false;
                    }

                    stringBuilder.Append(parameters[index3].ParameterType.Name);
                    stringBuilder.Append(' ');
                    stringBuilder.Append(parameters[index3].Name);
                }

                stringBuilder.Append(')');
            }

            stringBuilder.Append(Environment.NewLine);
        }
    }
}