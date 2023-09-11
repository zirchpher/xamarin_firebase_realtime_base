using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model;

namespace TodoApp.Services
{
    public class ReminderService
    {
        public async Task<List<Reminder>> GetReminders()
        {
            return (await DatabaseService.firebase
                .Child("reminders")
                .OnceAsync<Reminder>()).Select(reminder => new Reminder
                {
                    id = reminder.Key,
                    title = reminder.Object.title,
                    description = reminder.Object.description,
                    creation_date = reminder.Object.creation_date,
                    reminder_date = reminder.Object.reminder_date,
                    reminder_time = reminder.Object.reminder_time,
                }).ToList();
        }
    }
}
