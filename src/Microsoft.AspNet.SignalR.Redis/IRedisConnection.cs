// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace Microsoft.AspNet.SignalR.Redis
{
    public interface IRedisConnection
    {
        Task ConnectAsync(string connectionString, TraceSource trace);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        void Close(RedisChannel key, bool allowCommandsToComplete = true);

        Task SubscribeAsync(RedisChannel key, Action<int, RedisMessage> onMessage);

        Task ScriptEvaluateAsync(int database, string script, string key, byte[] messageArguments);

        Task RestoreLatestValueForKey(int database, string key);

        void Dispose();

        event Action<Exception> ConnectionFailed;
        event Action<Exception> ConnectionRestored;
        event Action<Exception> ErrorMessage;
    }
}
