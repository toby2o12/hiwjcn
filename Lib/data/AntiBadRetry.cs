﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.cache;
using Lib.helper;

namespace Lib.data
{
    public static class AntiBadRetry
    {
        /// <summary>
        /// 防止多次尝试密码逻辑，还没开始使用
        /// </summary>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string RedisPreventTryLogin(string key, Func<bool> func)
        {
            var time = DateTime.Now.AddMinutes(-30);
            using (var cache = CacheManager.CacheProvider())
            {
                var cachedata = cache.Get<List<DateTime>>(key);
                var list = cachedata.Success ? cachedata.Result : new List<DateTime>();
                list = ConvertHelper.NotNullList(list).Where(x => x > time).ToList();

                if (list.Count >= 3)
                {
                    //先判断验证码，否则提示错误
                    return "超过尝试次数";
                }

                if (!func.Invoke())
                {
                    //登录失败，添加错误时间
                    list.Add(DateTime.Now);
                }
                cache.Set(key, list, (int)Math.Abs((DateTime.Now - time).TotalSeconds));
                return "";
            }
        }
    }
}
