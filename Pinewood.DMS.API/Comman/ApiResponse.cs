namespace Pinewood.DMS.API.Comman
{
    public class ApiResponse
    {
        public bool Success { get; set; } = true;
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
        public object? Result { get; set; }
    }
}
