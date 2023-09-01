namespace spotify.bizlayer.Services.Manual;
public record GetAllStateResponse(IList<StateResponse> allStates);
public record StateResponse(int Id, string Name);
