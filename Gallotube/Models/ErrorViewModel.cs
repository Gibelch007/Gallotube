namespace Gallotube.Models;

public class ErrorViewModel
{
    public stringg RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
