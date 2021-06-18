using System;
using System.Reflection;

namespace LACC.Info
{
    // 해당 Attribute 구조는 https://phiru.tistory.com/249 를 참고했습니다.

    interface CollectData
    {
        string getValue();
    }

    public class ContentName : Attribute, CollectData
    {
        private string _value;

        public ContentName (string value)
        {
            _value = value;
        }

        public string getValue()
        {
            return _value;
        }
    }


    // Usage Example : EnumManager.GetContent(MindOfIsland.Libeheim)

    public static class EnumManager
    {
        private static string GetEnumValue(Type targetType, Object value)
        {
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            Attribute[] attrs = fi.GetCustomAttributes(targetType, false) as Attribute[];

            return (attrs.Length > 0) ? (attrs[0] as CollectData).getValue() : null;
        }

        public static string GetContent(Object value)
        {
            return GetEnumValue(typeof(ContentName), value);
        }

    }
}
