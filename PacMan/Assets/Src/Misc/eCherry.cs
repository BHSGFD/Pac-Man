namespace Game.Misc
{
    public enum eCherry
    {
        isActive,
        isInactive,
    }

    public static class Cherry
    {
       public static eCherry EnumCherry = eCherry.isInactive;
        public static bool GhostisDead = false;
        public static bool GhostisDeadAnother = false;

    }
}