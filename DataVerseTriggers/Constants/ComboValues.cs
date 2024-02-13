using DataVerseTrigger.Models;

namespace DataVerseTrigger.Constants
{
    public static class ComboValues
    {


        public static BindingItem[] MESSAGE_TYPES = new BindingItem[]
        {
            new BindingItem{Value="1", Description="Create" },
            new BindingItem{Value="2", Description="Delete" },
            new BindingItem{Value="3", Description="Update" },
            new BindingItem{Value="4", Description="CreateOrUpdate" },
            new BindingItem{Value="5", Description="CreateOrDelete" },
            new BindingItem{Value="6", Description="UpdateOrDelete" },
            new BindingItem{Value="7", Description="CreateOrUpdateOrDelete" },
        };

        public static BindingItem[] SCOPE = new BindingItem[]
        {
            new BindingItem{Value="1", Description="User" },
            new BindingItem{Value="2", Description="Business Unit" },
            new BindingItem{Value="3", Description="Parent Child Business Unit" },
            new BindingItem{Value="4", Description="Organization" }
        };



        public static BindingItem[] RUN_AS = new BindingItem[]
        {
                new BindingItem{Value="1", Description="Modifying User" },
                new BindingItem{Value="2", Description="Row Owner" },
                new BindingItem{Value="3", Description="Flow Owner" }
        };


        public static BindingItem[] WEEKDAYS = new BindingItem[]
        {
            new BindingItem{Value="Monday",Description="Monday"},
            new BindingItem{Value="Tuesday",Description="Tuesday"},
            new BindingItem{Value="Wednesday",Description="Wednesday"},
            new BindingItem{Value="Thursday",Description="Thursday"},
            new BindingItem{Value="Friday",Description="Friday"},
            new BindingItem{Value="Saturday",Description="Saturday"},
            new BindingItem{Value="Sunday",Description="Sunday"},
        };


        public static BindingItem[] FREQUENCY = new BindingItem[]
        {
            new BindingItem{Value="Month",Description="Month"},
            new BindingItem{Value="Week",Description="Week"},
            new BindingItem{Value="Day",Description="Day"},
            new BindingItem{Value="Hour",Description="Hour"},
            new BindingItem{Value="Minute",Description="Minute"},
            new BindingItem{Value="Second",Description="Second"},
        };


        public static BindingItem[] WORKFLOW_EVENTS = new BindingItem[]
        {
            new BindingItem{Value="Create", Description="Create" },
            new BindingItem{Value="Delete", Description="Delete" },
            new BindingItem{Value="Update", Description="Update" },
            new BindingItem{Value="StatusChange", Description="Status Change" },
            new BindingItem{Value="IsAssigned", Description="Is Assigned" }
        };


        public static BindingItem[] WORKFLOW_MODE = new BindingItem[]
        {
            new BindingItem{Value="0", Description="Background" },
            new BindingItem{Value="1", Description="Real-Time" }
        };


        public static BindingItem[] PLUGIN_STAGE = new BindingItem[]
          {
                new BindingItem{Value="10", Description="Pre-validation" },
                new BindingItem{Value="20", Description="Pre-operation" },
                new BindingItem{Value="40", Description="Post-operation" }
          };


        public static BindingItem[] PLUGIN_EXECUTION_MODE = new BindingItem[]
         {
                new BindingItem{Value="0", Description="Syncronous" },
                new BindingItem{Value="1", Description="Asyncronous" }
         };


    }
}
