using System;
using System.Text.Json;

namespace hackamole.quietu.api.Serialization
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToSnakeCase();
    }
}

