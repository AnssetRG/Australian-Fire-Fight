using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class QuoteData
{
    public List<Quote> Quotes;
}

[System.Serializable]
public class Quote
{
    public string sentence;
}