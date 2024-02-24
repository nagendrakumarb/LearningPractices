namespace MYProgressAdmin
{
    
    public class ActionStateItem
    {
        public UserActionStatus Status { get; set; }
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }

}
