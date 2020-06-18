namespace Fennec.Core.Entities.Users
{
    public class Visitor
    {
        public Visitor(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public string IpAddress { get; }
    }
}