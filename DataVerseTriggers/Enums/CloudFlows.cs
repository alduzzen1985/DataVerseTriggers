namespace DataVerseTrigger.Enums
{
    public enum Mode
    {
        Background = 0,
        Realtime = 1
    }

    public enum WorkflowScope
    {
        User = 1,
        BusinessUnit = 2,
        ParentChildBusinessUnit = 3,
        Organization = 4,
    }

    public enum MessageType
    {
        Create = 1,
        Delete = 2,
        Update = 3,
        CreateOrUpdate = 4,
        CreateOrDelete = 5,
        UpdateOrDelete = 6,
        CreateOrUpdateOrDelete = 7,
        NULL = 99
    }


    public enum Scope
    {
        User = 1,
        BusinessUnit = 2,
        ParentChildBusinessUnit = 3,
        Organization = 4,
        NULL = 99
    }


    public enum RunAs
    {
        ModifyingUser = 1,
        RowOwner = 2,
        FlowOwner = 3,
        NULL = 99
    }

    public enum ProcessType
    {
        CloudFlow = 1,
        Workflow = 2,
        Plugin = 3
    }


}
