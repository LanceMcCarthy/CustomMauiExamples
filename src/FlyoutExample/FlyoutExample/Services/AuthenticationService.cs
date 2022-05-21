namespace FlyoutExample.Services;

public class AuthenticationService
{
    public bool LogIntoSomeApiWithRefreshToken(string refreshToken)
    {
        // you would log the user in by getting a new access token with the old refresh token

        var updatedAccessToken = GetUpdatedAccessToken();

        Preferences.Set("UserAccessToken", updatedAccessToken);

        return true;
    }

    public bool LogIntoSomeApiWithCredentials(string username, string password)
    {
        if (username != "lance@domain.com" || password != "bad-password")
            return false;
        
        var updatedAccessToken = GetUpdatedAccessToken();

        Preferences.Set("UserAccessToken", updatedAccessToken);

        return true;
    }

    private string GetUpdatedAccessToken()
    {
        return "1234";
    }

    // simulate logging out by clearing user creds
    public bool LogOut()
    {
        Preferences.Set("UserAccessToken", null);

        return true;
    }
}
