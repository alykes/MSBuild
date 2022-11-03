using Microsoft.Build.Framework;

namespace Pluralsight.MSBuild.Tasks
{
    public class Add2Numbers : ITask
    {
        [Required]
        public double Number1 { get; set; }
        
        [Required]
        public double Number2 { get; set; }

        [Output]
        public double Result { get; set; }

        public bool Execute()
        {
            Result = Number1 + Number2;

            BuildEngine.LogMessageEvent(new BuildMessageEventArgs("Added 2 numbers", "Math", "Add2Numbers", MessageImportance.High));

            return true;
        }

        public IBuildEngine BuildEngine { get; set; }

        public ITaskHost HostObject { get; set; }
    }
}