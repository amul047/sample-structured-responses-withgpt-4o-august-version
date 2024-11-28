// Define response format types
public sealed class EmailResult
{
    /// <summary>
    /// Emails.
    /// </summary>
    public List<Email> Emails { get; set; } = new List<Email>();
}

public sealed class Email
{
    /// <summary>
    /// Body.
    /// </summary>
    public required string Body { get; set; }

    /// <summary>
    /// Category.
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// Mood.
    /// </summary> 
    // TODO: #2 Add Mood
    public required string Mood { get; set; }

    /// <summary>
    /// Mood.
    /// </summary> 
    // TODO: #2 Add Mood
    public required string Subject { get; set; }
}
