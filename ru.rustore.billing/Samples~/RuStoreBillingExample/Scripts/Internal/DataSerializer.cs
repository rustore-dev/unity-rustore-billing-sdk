using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace RuStore.BillingExample {

    public static class DataSerializer {

        public static string SerializeToJson(object obj, bool prettyPrint = false) {
            return SerializeToJson(obj, prettyPrint, 0);
        }

        private static string SerializeToJson(object obj, bool prettyPrint, int indentLevel) {
            if (obj == null) return "null";

            if (obj is string str) return $"\"{str}\"";
            if (obj is Enum enumValue) return $"\"{enumValue}\"";
            if (IsNumeric(obj)) return obj.ToString();
            if (obj is bool boolValue) return boolValue.ToString().ToLower();
            if (obj is ICollection collection) return SerializeCollection(collection, prettyPrint, indentLevel);
            if (obj is DateTime) return SerializeDateTime(obj);

            return SerializeObject(obj, prettyPrint, indentLevel);
        }

        private static string SerializeDateTime(object obj) {
            var dateString = (obj as DateTime?)?.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return $"\"{dateString}\"";
        }

        private static string SerializeCollection(ICollection collection, bool prettyPrint, int indentLevel) {
            if (collection.Count == 0) return "[]";

            var sb = new StringBuilder();
            sb.Append("[");

            string indent = prettyPrint ? GetIndent(indentLevel + 1) : "";
            bool first = true;

            foreach (object item in collection) {
                if (!first) sb.Append(",");
                first = false;

                if (prettyPrint) {
                    sb.AppendLine();
                    sb.Append(indent);
                }

                sb.Append(SerializeToJson(item, prettyPrint, indentLevel + 1));
            }

            if (prettyPrint) {
                sb.AppendLine();
                sb.Append(GetIndent(indentLevel));
            }

            sb.Append("]");

            return sb.ToString();
        }

        private static string SerializeObject(object obj, bool prettyPrint, int indentLevel) {
            Type type = obj.GetType();
            var sb = new StringBuilder();
            sb.Append("{");

            var properties = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            if (properties.Length == 0) return "{}";

            string indent = prettyPrint ? GetIndent(indentLevel + 1) : "";
            bool first = true;

            foreach (var prop in properties) {
                if (!first) sb.Append(",");
                first = false;

                if (prettyPrint) {
                    sb.AppendLine();
                    sb.Append(indent);
                }

                sb.Append($"\"{prop.Name}\":");
                if (prettyPrint) sb.Append(" ");

                object value = prop.GetValue(obj);
                sb.Append(SerializeToJson(value, prettyPrint, indentLevel + 1));
            }

            if (prettyPrint) {
                sb.AppendLine();
                sb.Append(GetIndent(indentLevel));
            }

            sb.Append("}");

            return sb.ToString();
        }

        private static bool IsNumeric(object value) =>
            value is int or long or float or double or decimal;

        private static string GetIndent(int level) =>
            new string(' ', level * 4);
    }
}
