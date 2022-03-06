namespace TypeScriptExecutionPoC;

public interface IJavascriptExecutor
{
    Task<string> Execute(string scriptName, object[] arguments);
}