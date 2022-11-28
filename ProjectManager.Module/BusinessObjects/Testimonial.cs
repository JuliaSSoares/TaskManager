using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Marketing")]
    public class Testimonial : BaseObject
    { 
        public Testimonial(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string _caseStudy;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CaseStudy
        {
            get => _caseStudy;
            set => SetPropertyValue(nameof(CaseStudy), ref _caseStudy, value);
        }

        string _description;

        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get => _description;
            set => SetPropertyValue(nameof(Description), ref _description, value);
        }

        Customer _customer;
        [Association("Customer-Testimonials")]
        public Customer Customer
        {
            get => _customer;
            set => SetPropertyValue(nameof(Customer), ref _customer, value);
        }
    }
}