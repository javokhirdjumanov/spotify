namespace spotify.bizlayer.Services.Manual;
public record GetAllStatusResponse(IList<StatusResponse> allStatus);
public record StatusResponse(int Id, string Name);
