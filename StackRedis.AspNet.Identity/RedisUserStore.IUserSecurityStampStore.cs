﻿/*
    Copyright 2015 Matías Fidemraizer (https://linkedin.com/in/mfidemraizer)
    
    "StackRedis.AspNet.Identity" project (https://github.com/mfidemraizer/StackRedis.AspNet.Identity)

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
 
    You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/

namespace StackRedis.AspNet.Identity
{
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;

    public partial class RedisUserStore<TUser> : IUserSecurityStampStore<TUser>
    {
        public virtual Task<string> GetSecurityStampAsync(TUser user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        public virtual Task SetSecurityStampAsync(TUser user, string stamp)
        {
            user.SecurityStamp = stamp;

            return Task.FromResult(true);
        }
    }
}