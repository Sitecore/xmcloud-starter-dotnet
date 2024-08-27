using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models;

public class DataField
{
    [JsonPropertyName("datasource")]
    public DatasourceField? Datasource { get; set; }
}