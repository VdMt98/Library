using Library.Models;
using Library.Models.TableElements;
using Library.Models.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class ReaderMainWindowController
    {
        public ObservableCollection<BookRow> createTable()
        {
            ObservableCollection<BookRow> bookRowlist = new ObservableCollection<BookRow>(DAO.GetBookTable().GetRowsOfBooksInuseByRecipient(Main.Instance.worker.id));
            return bookRowlist;
        }
    }
}
