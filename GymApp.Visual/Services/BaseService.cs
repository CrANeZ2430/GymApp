using System.Text.Json;
using System.Text.Json.Serialization;

namespace GymApp.Visual.Services;

public abstract class BaseService(HttpClient client)
{
    protected HttpClient _client = client;
    protected JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };
}
