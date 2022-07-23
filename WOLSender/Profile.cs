namespace WOLSender
{
    class Profile
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public int PortNumber { get; set; }
        public bool IsLocal { get; set; }

        public Profile(string profile, string ipAddress, string macAddress, int portNumber, bool isLocal)
        {
            this.Name = profile;
            this.IPAddress = ipAddress;
            this.MACAddress = macAddress;
            this.PortNumber = portNumber;
            this.IsLocal = isLocal;
        }
    }
}