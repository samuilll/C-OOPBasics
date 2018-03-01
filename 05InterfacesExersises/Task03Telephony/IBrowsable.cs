
    using System.Collections.Generic;

public interface ISmartPhone:IPhone
    {
        List<string> UrlList { get; }

        string PrintUrl(string url);
    }
