using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    public class PaymentModel
    {
        private string name;
        private string adress;
        private string email;

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetAdress()
        {
            return adress;
        }
        public void SetAdress(string adress)
        {
            this.adress = adress;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }

        public void ClearInfo()
        {
            name = null;
            adress = null;
            email = null;
        }
    }
}
