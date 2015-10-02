using System;

namespace ResolutionTest
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (ResolutionTest game = new ResolutionTest())
            {
                game.Run();
            }
        }
    }
#endif
}

