
internal interface Icontact
{
    string email { get; set; }
    long phone { get; set; }


    string  GetContactDetails();
}

