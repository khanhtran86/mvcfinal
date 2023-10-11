using System;
namespace mvcprojectfinal
{
	public static class SessionHelper
	{
		public static void Add<T>(this ISession session, string key, T obj)
		{
			String stringToSession = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

			session.SetString(key, stringToSession);

		}

		public static void Set<T>(this ISession session, string key, T obj)
		{
            String stringToSession = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            session.SetString(key, stringToSession);
        }

		public static T Get<T>(this ISession session, string key)
		{
			String stringFromSession = session.GetString(key);
			if(!string.IsNullOrEmpty(stringFromSession))
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringFromSession);
			}

			return default(T);
		}
	}
}

