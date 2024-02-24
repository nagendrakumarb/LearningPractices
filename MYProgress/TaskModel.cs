namespace MYProgressAdmin
{
    public partial class MYCenter
    {
        // Data model class
        public class TaskModel
        {
            public Guid TaskModelIdx { get; set; }
            public string TaskModelName { get; set; }
            public string Description { get; set; }
            public string TaskPageUrl { get; set; }
            public int? EpicId { get; set; }
            public int? FeatureId { get; set; }
            public int? UserStoryId { get; set; }
            // Add other properties...

            public override string ToString()
            {
                return TaskModelName;
            }
        }
    }

}



