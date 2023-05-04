using System.Text.Json;

namespace UpgradeERP.Servicios
{
    public static class Extension
    {
        public static void SetObject(this ISession session, string key, Object value)
        {
            string data = JsonSerializer.Serialize(value);
            session.SetString(key, data);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            else
            {
                return JsonSerializer.Deserialize<T>(data);
            }
        }

    }
}
