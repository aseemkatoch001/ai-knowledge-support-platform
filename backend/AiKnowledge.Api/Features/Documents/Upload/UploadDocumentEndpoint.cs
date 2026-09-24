using AiKnowledge.Application.Documents.Upload;

namespace AiKnowledge.Api.Features.Documents.Upload
{
    public static class UploadDocumentEndpoint
    {
        public static IEndpointRouteBuilder MapUploadDocumentEndpoint(
            this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost(
                "/api/documents",
                async (
                    IFormFile file,
                    IUploadDocumentHandler handler,
                    CancellationToken cancellationToken) =>
                {
                    if (file.Length == 0)
                    {
                        return Results.BadRequest("File is required.");
                    }

                    var command = new UploadDocumentCommand(file.OpenReadStream(),file.FileName);

                    var result = await handler.HandleAsync(
                        command,
                        cancellationToken);

                    return Results.Created(
                        $"/api/documents/{result.Id}",
                        result);
                })
                .WithName("UploadDocument")
                .WithTags("Documents")
                .DisableAntiforgery();

            return endpoints;
        }
    }
}
