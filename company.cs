
    class Company:Icommunication
    {
        private string _city;
        private string _country;
        private int _pincode;
        private string _email;
        private long _phone;
        

      
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        public string country
        {
            set { _country = value; }
            get { return _country; }
        }

        public int pincode
        {
            set { _pincode = value; }
            get { return _pincode; }
        }

        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        public long phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        public string GetAddressDetails()
        {
            return "Manager Address is " + _city + " " + _country + " " + _pincode;
        }

        public string GetContactDetails()
        {
            return "Manager Contact is " + _email + " " + "phone :" + _phone;
        }

        public string GetCommunicationDetails()
        {
            return "Manager email" +_email ;
        }

    }
