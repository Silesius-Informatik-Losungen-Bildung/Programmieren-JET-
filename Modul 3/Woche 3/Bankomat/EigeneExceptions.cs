namespace Bankomat
{
    public class EigeneExceptions
    {

        public class FalscheKarteException : Exception
        {
            public FalscheKarteException() : base("Ihre Bankomatkarte wird nicht unterstützt!")
            {
            }
        }

        public class BetragMussGrößer0Sein : Exception
        {
            public BetragMussGrößer0Sein() : base("Betrag muss größer als 0 sein!")
            {
            }
        }

        public class FalschePinException : Exception
        {
            public FalschePinException() : base("Die eingegebene PIN ist leider falsch!")
            {
            }
        }

        public class NichtGenügendGuthabenException : Exception
        {
            public NichtGenügendGuthabenException() : base("Nicht genügend Guthaben!")
            {
            }
        }
    }
}
