using CRUD_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Xamarin.Services.Statements
{
    public interface IStatementService 
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
    }
}
