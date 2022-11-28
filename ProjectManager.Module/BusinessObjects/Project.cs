using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace ProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Project : BaseObject
    {
        public Project(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string _projectName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProjectName
        {
            get => _projectName;
            set => SetPropertyValue(nameof(ProjectName), ref _projectName, value);
        }

        Employee _assignedTo;
        [Association("Employee-Projects")]
        public Employee AssignedTo
        {
            get=> _assignedTo;
            set => SetPropertyValue(nameof(AssignedTo), ref _assignedTo, value);
        }

        [Association("Project-Tasks")]
        public XPCollection<ProjectTask> ProjectTasks
        {
            get => GetCollection<ProjectTask>(nameof(ProjectTasks));
        }

        Customer _customer;
        [Association("Customer-Projects")]
        public Customer Customer
        {
            get => _customer;
            set => SetPropertyValue(nameof(Customer), ref _customer, value);
        }
    }
}