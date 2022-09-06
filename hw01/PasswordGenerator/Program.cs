using System;

namespace PasswordGenerator
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var passwordGenerator = new PasswordGenerator();

            for (var i = 0; i < 10; ++i)
            {
                Console.WriteLine(passwordGenerator.Generate());
            }
            /*
                SEeZMfjz_RagQIskw
                2FKaCHxrUlWSuE_GP
                4V8_2Z1S3T
                O_EDMIKT
                3R6V8FGJ_MKYATNcPUID
                ERX_LK
                3STZBKIA_CDLPFVONMH
                6k9y2Od_cfWbIrGAUJ
                7B9Z_HGODRLvTUdJMFQS
                0_jORslZ
             */
        }
    }
}