using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseDesign.Models
{
    internal class User
    {
        private String id;
        private String name;
        private String email;
        private String phone;

        public User(String id, String name, String email, String phone)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public String Id {
            get
            {
                return id; 
            }  
        }

        public String Name
        {
            get
            {
                return name;
            }
        }


    }
}
