using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace ProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Marketing")]
    public class Customer : BaseObject
    {
        public Customer(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string _name;
        public string Name
        { 
            get => _name; 
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

        string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetPropertyValue(nameof(LastName), ref _lastName, value);
        }

        string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber), ref _phoneNumber, value);
        }

        [Association("Customer-Projects")]
        public XPCollection<Project> Projects
        {
            get => GetCollection<Project>(nameof(Projects));
        }


        [Association("Customer-Testimonials")]
        public XPCollection<Testimonial> Testimonials
        {
            get => GetCollection<Testimonial>(nameof(Testimonials));
        }
    }
}