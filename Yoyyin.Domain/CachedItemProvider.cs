using System;
using System.Web;
using System.Web.Caching;

namespace Yoyyin.Domain
{
    public class CachedItemProvider<T>
    {
        public T GetItem(string key, Delegate alternativeGetMethod)
        {
            if (HttpContext.Current != null && HttpContext.Current.Cache[key] != null)
                return (T)HttpContext.Current.Cache[key];
            
            var cachedItem = (T)alternativeGetMethod.DynamicInvoke(null);
            AddToCache(cachedItem, key);
            return cachedItem;
        }

        public void AddToCache(T item, string key)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Cache.Insert(key, item, null, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration);
        }
    }
}