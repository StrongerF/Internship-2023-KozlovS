using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductStoreClassLibrary.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int RoleID { get; set; }

        public string EmployeeVisibility
        {
            get
            {
                if (RoleID == 1)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public string ClientVisibility
        {
            get
            {
                if (RoleID == 2)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

    }
}
