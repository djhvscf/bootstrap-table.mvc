using System;
using System.Reflection;

namespace BootstrapTable.Support
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class NameFieldAttribute : Attribute
    {
        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class ValueFieldAttribute : NameFieldAttribute
    {
        public string Value { get; set; }
    }

    internal static class FieldAttributeExtensions
    {
        public static string FieldName(this Enum value)
        {
            var attr = value.GetType().GetField(value.ToString()).GetCustomAttribute<NameFieldAttribute>();
            return attr.IsNotNull() ? attr.Name : null;
        }

        public static string FieldValue(this Enum value)
        {
            var attr = value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueFieldAttribute>();
            return attr.IsNotNull() ? attr.Value : null;
        }
    }
}

