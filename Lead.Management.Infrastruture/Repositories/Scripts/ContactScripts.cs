namespace Lead.Management.Infrastruture.Repositories.Scripts
{
    public static class ContactScripts 
    {
        public const string LIST_CONTACTS = @"Select * From Contacts";

        public const string CONTACT_OBTER = @"Select * From Contacts Where Id = @Id";

        public const string CONTACT_ACCEPT = @"Select * From Contacts Where Accept = @Accept";

        public const string CONTACT_ADD = @"Insert Into Contacts
                                            (
                                                FirstName,
                                                FullName,
                                                PhoneNumber,
                                                Email,
                                                Suburb,
                                                Category,
                                                Description,
                                                Price,
                                                Accept
                                            )
                                            Values 
                                            (
                                                @FirstName,
                                                @FullName,
                                                @PhoneNumber,
                                                @Email,
                                                @Suburb,
                                                @Category,
                                                @Description,
                                                @Price,
                                                0
                                            )";

        public const string UPDATE_CONTACT_ACCEPT = @"Update Contacts 
                                                      SET Accept = 1 
                                                      where Id = @Id";

        public const string UPDATE_CONTACT_DECLINE = @"Update Contacts 
                                                      SET Accept = 0 
                                                      where Id = @Id";
    }
}
