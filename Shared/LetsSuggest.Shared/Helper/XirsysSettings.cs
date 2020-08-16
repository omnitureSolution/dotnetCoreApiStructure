namespace LetsSuggest.Shared.Helper
{
    public class XirsysSettings
    {
        public string GateWay { get; set; }
        public string[] AllowedServices { get; set; }
        public bool OverrideAllowedChannel { get; set; }
        public XirsysInfo Info { get; set; }
        public string Version { get; set; }
        public string ApiLayer { get; set; }
        public int Depth { get; set; }
    }

    public class XirsysInfo
    {
        public string Ident { get; set; }
        public string Secret { get; set; }
        public string Channel { get; set; }
    }
}

