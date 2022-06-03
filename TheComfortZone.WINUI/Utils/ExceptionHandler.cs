using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TheComfortZone.WINUI.Utils
{
    public static class ExceptionHandler
    {
        public static T HandleException<T>(Dictionary<string, dynamic> errors)
        {
            var errorKeyValuePair = errors.First(x => x.Key == "errors");
            string errorString = string.Join(",", errorKeyValuePair.Value);
            var errorDictionary = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errorString);
            var stringBuilder = new StringBuilder();
            foreach (var error in errorDictionary)
            {
                stringBuilder.AppendLine($"{error.Key}:\n{string.Join("\n", error.Value)}");
            }

            MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return default;
        }
    }
}
