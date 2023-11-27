
    internal interface IAddress
    {
    string city { get; set; }
    string country { get ; set; }   

    int pincode { get; set; }

    string GetAddressDetails();
    }

