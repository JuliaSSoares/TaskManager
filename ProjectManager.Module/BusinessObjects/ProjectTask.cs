using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace ProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class ProjectTask : BaseObject
    {
        public ProjectTask(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Status = Status.ToDo;
        }

        Project _project;
        [Association("Project-Tasks")]
        public Project Project
        {
            get => _project;
            set => SetPropertyValue(nameof(Project),ref _project, value);
        }

        string _subject;
        public string Subject 
        { 
            get => _subject;
            set => SetPropertyValue(nameof(Subject), ref _subject, value);
        }

        DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => SetPropertyValue(nameof(StartDate), ref _startDate, value);
        }

        DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetPropertyValue(nameof(EndDate), ref _endDate, value);
        }

        Status _status;
        public Status Status
        { 
            get => _status;
            set => SetPropertyValue(nameof(Status),ref _status, value);
        }
    }
}