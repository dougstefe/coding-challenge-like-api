using NJsonSchema.Generation;
using System;

namespace CodingChallengeLike.Api.Swagger
{
    public class CustomSchemaNameGenerator : ISchemaNameGenerator
    {
        public string Generate(Type type) =>
         type.FullName.Replace("ViewModel", string.Empty);
    }
}
