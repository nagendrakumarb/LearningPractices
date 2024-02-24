namespace MYProgressAdmin
{
    public enum ProcessStages
    {
        Initialization = 1,
        Collection = 2,
        Review = 3,
        Approval = 4,
        Execution = 5,
        Monitoring = 6,
        Completion = 7,
        Archiving = 8,
        OnHold = 9,
        Cancelled = 10,
        Rejected = 11,
        Revision = 12
    }
    public enum WorkflowStates
    {
        Draft = 1,
        PendingApproval = 2,
        InReview = 3,
        Approved = 4,
        Rejected = 5,
        PendingDelegation = 6,
        Delegated = 7,
        Expired = 8,
        Canceled = 9,
        Withdrawn = 10,
        Revised = 11
    }
    public enum TaskPriority
    {
        Idle = 4,
        BelowNormal = 6,
        Normal = 8,
        AboveNormal = 10,
        High = 13,
        RealTime = 24
    }
    public enum UserActionStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
    public enum UploadFileSourceTypesEnum
    {
        Csv = 0,
        Image = 1,
    }
}
