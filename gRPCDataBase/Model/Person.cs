using Google.Protobuf.Collections;

namespace gRPCDataBase.Model
{
    public class Person
    {
        public RepeatedField<string> Roles { get; }
    }
}
