using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.EfBasics.Web.Services.Interfaces
{
    public interface ISessionServices
    {
        void AddStudentToSessionList(string studentName);
        void RemoveStudentFromSessionList(string studentName);
        List<string> GetStudentListFromSession();

    }
}
