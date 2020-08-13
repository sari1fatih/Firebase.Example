using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System; 
using System.IO;
using System.Threading.Tasks;

namespace Firebase.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
             try
             {
                string body = "Hayırlı Cumalar.\nSana Güveniyoruz\nNamazlarını ihmal etme";
                 var defaultApp = FirebaseApp.Create(new AppOptions()
                 {
                     Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")) 
                 });
                 Console.WriteLine(defaultApp.Name); // "[DEFAULT]"


                 var message = new Message()
                 {
                     Notification = new Notification
                     {
                         Title = "Profesör",
                         Body = body
                     }, 
                     Token = @"d1v616Yv92To-tHquJrMCfqK:APA91bHN4kVB7P8PIBs6yofxd8iXr_UbIuTGLdhIFtSgCVLPmpEXnO8rFJ09uL6rD0lPivG-N2E7v8gtxWbmWXoXKKSF720teD6JyaHTFrDk0kXe6fgv8UlFJyTlV2jF7NqWuyDTF6jj", 
                     //Condition = "'news' in topics || 'low-activity' in topics",
                     //Topic ="a1"
                 };
                 var messaging = FirebaseMessaging.DefaultInstance;

                 var result = await messaging.SendAsync(message);
                 Console.WriteLine(result); //projects/myapp/messages/2492588335721724324
             }
             catch (Exception ex)
             {

                
             } 
            
        }
    }
}
