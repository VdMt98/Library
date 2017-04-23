using Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class SearchClientController
    {
        public ObservableCollection<BookRow> Startup()
        {
            ObservableCollection<BookRow> bookRowlist = new ObservableCollection<BookRow>(DAO.GetBookTable().GetRowsOfBooksInuseByRecipient(Main.Instance.client.id));
            return bookRowlist;
        }
    }
}
