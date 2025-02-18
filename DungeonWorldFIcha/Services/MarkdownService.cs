using Markdig;

namespace DungeonWorldFIcha.Services;

public class MarkdownService
{
    private readonly MarkdownPipeline _pipeline;

    public MarkdownService()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()  // Inclui tabelas e outras melhorias
            .UseTaskLists()           // Suporte para checkboxes
            .Build();
    }

    public string ConvertToHtml(string markdown)
    {
        if (markdown is null)
        {
            return string.Empty;
        }
        return Markdown.ToHtml(markdown, _pipeline);
    }  
}