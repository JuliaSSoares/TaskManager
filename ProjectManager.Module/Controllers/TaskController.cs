using DevExpress.CodeParser;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ProjectManager.Module.BusinessObjects;
using System;

namespace ProjectManager.Module.Controllers
{
    public class TaskController : ViewController
    {
        readonly SimpleAction _complete;
        readonly SimpleAction _deferred;
        readonly SimpleAction _inProgress;
        readonly SimpleAction _toDo;

        public TaskController()
        {
            TargetObjectType = typeof(ProjectTask);

            TaskAction(_toDo, "To Do");
            TaskAction(_inProgress, "In Progress");
            TaskAction(_complete, "Completed");
            TaskAction(_deferred, "Deferred" );
        }

        private void TaskAction(SimpleAction smlpAct, string parameterName )
        {
            smlpAct = new SimpleAction(this, parameterName, PredefinedCategory.Edit)
            {
                SelectionDependencyType = SelectionDependencyType.RequireSingleObject
            };
            smlpAct.Execute += Execute;
        }

        private void Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (e.CurrentObject is ProjectTask currentObj)
                currentObj.Status = VerifyStatus(e);

            if (this.ObjectSpace.IsModified)
                this.ObjectSpace.CommitChanges();
        }

        private Status VerifyStatus(SimpleActionExecuteEventArgs e)
        {
            switch (e.Action.Id)
            {
                case "To Do":
                    return Status.ToDo;
                case "In Progress":
                    return Status.InProgress;
                case "Completed":
                    return Status.Completed;
                case "Deferred":
                    return Status.Deferred;
                default:
                    throw new Exception("Unrecognized action value!");
            }
        }
    }
}
