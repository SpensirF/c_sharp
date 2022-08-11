namespace CreatePassword;

public class Password
{

    public string[] PasscodeList = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

    public string GeneratePassword()
    {
        string Passcode = "";
        Random rand = new Random();
        for( int i = 0; i < 14; i++ )
        {
            int randomIndex = rand.Next( 0, PasscodeList.Count() );
            string randomIndexChar = PasscodeList[ randomIndex ];
            Passcode += randomIndexChar; 
        }

        return Passcode;
    }

}