using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace TodoApp.Services
{
    public class DatabaseService
    {
        public static FirebaseClient firebase = new FirebaseClient("https://todoapp-38944-default-rtdb.firebaseio.com");
    }
}
