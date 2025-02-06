namespace InfoSecLab
{
    public static class HashUtils
    {
        public static String HashPassword(String password)
        {
            String pepperedPassword = password + Program.Pepper;
            return BCrypt.Net.BCrypt.EnhancedHashPassword(pepperedPassword);
        }
        public static bool VerifyPassword(String password, String storedHash)
        {
            String pepperedPassword = password + Program.Pepper;
            return BCrypt.Net.BCrypt.Verify(pepperedPassword, storedHash, true);
        }
    }
}
