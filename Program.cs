// Initialize kernel.
using Azure.Identity;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using StructuredOutputsDemoWithSemanticKernel;
using System.Text.Json;
using table.lib;

Kernel kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(
        deploymentName: Config.DeploymentName,
        endpoint: Config.Endpoint,
        new DefaultAzureCredential()) // Ensure you have Cognitive OpenAI User role setup for your Azure OpenAI instance.
    .Build();

#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
var executionSettings = new OpenAIPromptExecutionSettings
{
    // TODO: #1 Enable structured outputs
    ResponseFormat = typeof(EmailResult), // Specify response format
};
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

// Send a request and pass prompt execution settings with desired response format.
var result = await kernel.InvokePromptAsync("Give me five sample one-sentence long emails!", new(executionSettings));

Console.WriteLine(result);

// TODO: #3 Display the results nicely
var emailResult = JsonSerializer.Deserialize<EmailResult>(result.ToString());
Table<Email>.Add(emailResult?.Emails).ToConsole();
