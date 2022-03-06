using Newtonsoft.Json;

namespace TypeScriptExecutionPoC;

public class JavascriptResponse
{
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("data")]
    public string Data { get; set; }
}