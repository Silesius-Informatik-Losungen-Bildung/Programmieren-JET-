using static TypesCommonNames.Enums;

namespace TypesCommonNames
{
    public class InsertUpdateResponse
    {
        public StatusEnum Status { get; set; }
        public string? Error { get; set; }

        public List<MyHeritage>? List { get; set; }

        public int AllCount { get; set; }

    }
}