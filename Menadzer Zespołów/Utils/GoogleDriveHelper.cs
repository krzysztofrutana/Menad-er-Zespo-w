using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Menadzer_Zespołów.Utils
{
    public class GoogleDriveHelper
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string[] Scopes = { DriveService.Scope.DriveFile, "email" };
        static string ApplicationName = "Menadzer Zespolow";

        UserCredential credential;

        public DriveService GetGoogleDriveService()
        {
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/menadzer_zespolow_token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                return service;
            }
            
        }

        //public String GetAccountEmail()
        //{

        //    // code to get account name or email there
        //    return accountNameOrEmail;
        //}

    }


}

