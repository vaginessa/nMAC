using System;

namespace nMAC.Devices
{
    class Nexus5 : DeviceModel
    {
        internal Nexus5()
        {
            this.Path = "/persist/wifi/.macaddr";
        }

        internal override bool CheckFile(byte[] content)
        {
            if(content.Length != 6)
                return false;

            return true;
        }

        internal override string ExtractMACFromFile(byte[] content)
        {
            return BitConverter.ToString(content).Replace("-", string.Empty);
        }

        internal override void WriteMAC(ref byte[] content, string MAC)
        {
            content = this.GetMACBytes(MAC);
        }
    }
}