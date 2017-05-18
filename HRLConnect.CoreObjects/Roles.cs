namespace HRLConnect.CoreObjects
{
    public class Role
    {
        public static string SuperAdmin { get; set; }
        public static string SeniorMgrAndMgr { get; set; }
        public static string AmAndTL { get; set; }
        public static string Others { get; set; }

        static Role()
        {
            SuperAdmin = "SuperAdmin";
            SeniorMgrAndMgr = "SeniorMgrAndMgr";
            AmAndTL = "AmAndTL";
            Others = "Others";
        }
    }
}
