using CRUD_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Xamarin.Services.Statements
{
    public class MockStatementsService : IStatementService
    {
        private List<PayStatement> _items;
        public MockStatementsService()
        {
            _items = new List<PayStatement>()
            {
                new PayStatement
                {
                    Amount = 10,
                    Date = DateTime.Parse("08/26/2021"),
                    Start = DateTime.Parse("07/15/2021"),
                    End = DateTime.Parse("10/16/2021"),

                    WorkItems = new List<WorkItem>
                    {
                        new WorkItem
                        {
                            Start = DateTime.Parse("06/06/2021 12:00:00"),
                            End = DateTime.Parse("06/06/2021 15:00:00")
                        }
                    }

                }
            };
        }
        public Task<List<PayStatement>> GetStatementHistoryAsync()
        {
            return Task.FromResult(_items);
        }
    }
}
