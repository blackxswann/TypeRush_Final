namespace TypeRush_Final
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string DisplayName { get; set; }
        public static string Password { get; set; }
        public static string EmailAddress { get; set; }
        public static int AvatarIndex { get; set; }
        public static string DisplayPicturePath { get; set; }
        public static string currentLevel { get; set; }
        public static string levelName { get; set; }
        public static string XPRequired { get; set; }
        public static string XP { get ; set; }
        public static string NextLevelID { get; set; }
        public static string NextLevelName { get; set; }
        public static string NextLevelXPRequired { get; set; }

        public static void Clear()
        {
            UserID = 0;
            Username = null;
            DisplayName = null;
            Password = null;
            EmailAddress = null;
            AvatarIndex = -1;
            DisplayPicturePath = "NO_PICTURE_UPLOADED";
        }
    }
}