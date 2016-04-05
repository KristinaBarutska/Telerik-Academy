namespace School
{
    using System.Collections.Generic;

    public interface IComment
    {
        IEnumerable<string> Comments { get; } 
    }
}