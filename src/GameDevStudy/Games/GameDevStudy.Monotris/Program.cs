namespace GameDevStudy.Monotris
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MonotrisGame())
                game.Run();
        }
    }
}