namespace TypeScriptExecutionPoC;

public class ScriptFactory
{
    public async Task<string> GetScript(string scriptName)
    {
        var script = scriptName switch
        {
            "generateAst" => await File.ReadAllTextAsync($"scripts/{scriptName}.js"),
            "generateCode" => await File.ReadAllTextAsync($"scripts/{scriptName}.js"),
            _ => throw new FileNotFoundException($"Script with the name '{scriptName}' could not be found")
        };

        return script;
    }
}