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
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public partial class RedisUserStore<TUser> : IUserClaimStore<TUser>
    {
        public virtual Task AddClaimAsync(TUser user, Claim claim)
        {
            return Database.SetAddAsync(string.Format(UserClaimSetKey, ((IUser)user).Id), JsonConvert.SerializeObject(claim));
        }

        public virtual async Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            return (IList<Claim>)(await Database.SetMembersAsync(string.Format(UserClaimSetKey, ((IUser)user).Id)))
                                            .Select(rawClaim => JsonConvert.DeserializeObject<Claim>(rawClaim))
                                            .ToList();
        }

        public virtual Task RemoveClaimAsync(TUser user, Claim claim)
        {
            return Database.SetRemoveAsync(string.Format(UserClaimSetKey, ((IUser)user).Id), JsonConvert.SerializeObject(claim));
        }
    }
}