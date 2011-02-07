namespace OpenAnt
{
#if WINDOWS || XBOX
    /// <summary>
    /// The program entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Program launch arguments.
        /// </param>
        public static void Main(string[] args)
        {
            using (var game = new OpenAnt())
            {
                game.Run();
            }
        }
    }
#endif
}

