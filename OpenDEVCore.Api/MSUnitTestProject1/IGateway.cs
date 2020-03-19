using Core.Mvc;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTestProject1
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IGateway : IProxy
    {

    }
}
