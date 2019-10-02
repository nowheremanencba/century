//
// Copyright (C) by daxnet 2016
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ---------------------------------------------------------------------------------------------------------------

using System;

namespace Domain.Core.Messaging
{
    /// <summary>
    /// Represents that the implemented classes are message consumers.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IMessageConsumer : IDisposable
    {
        /// <summary>
        /// Gets the instance of <see cref="IMessageSubscriber"/> which will
        /// subscribe to the message bus and notify the current instance when
        /// there is any message comes in.
        /// </summary>
        /// <value>
        /// The instance of <see cref="IMessageSubscriber"/> which subscribes
        /// to the message bus and notify the current instance when any message
        /// comes in.
        /// </value>
        IMessageSubscriber Subscriber { get; }
    }
}
