
    using System.Collections.Generic;

public interface IPhone
    {
        string Model { get; }
        List<string> PhoneNumbersList { get; }
        string PrintPhoneNumber(string phoneNumber);

    }
